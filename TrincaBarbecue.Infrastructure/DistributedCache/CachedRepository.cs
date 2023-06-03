using Microsoft.Extensions.Caching.StackExchangeRedis;
using StackExchange.Redis;
using System.Text.Json;
using TrincaBarbecue.SharedKernel.Interfaces;

namespace TrincaBarbecue.Infrastructure.DistributedCache
{
    public class CachedRepository<TEntity> : ICachedRepository<TEntity>, IDisposable
        where TEntity : IEntity<Guid>, IAggregateRoot
    {
        private readonly IDatabase _distributedCache;
        private readonly ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379");

        public CachedRepository()
        {
            _distributedCache = redis.GetDatabase();
        }

        public TEntity? Get(string key)
        {
            var output = _distributedCache.ListRange(key, 0, -1);

            if (output.Length == 0) return default(TEntity);

            return JsonSerializer.Deserialize<TEntity>(output[0]);
        }

        public void Set(string key, TEntity value)
        {
            var input = JsonSerializer.Serialize(value);
            _distributedCache.ListRightPush(key, input);
        }

        IEnumerable<TEntity> ICachedRepository<TEntity>.GetAll()
        {
            var redis = ConnectionMultiplexer.Connect("localhost:6379");
            ICollection<TEntity> entities = new List<TEntity>();

            RedisKey[] keys = redis
                .GetServer("localhost:6379")
                .Keys(pattern: "*")
                .ToArray();

            foreach (var key in keys)
            {
                if (_distributedCache.KeyType(key) == RedisType.List)
                {
                    RedisValue[] values = _distributedCache.ListRange(key);

                    foreach (RedisValue value in values)
                    {
                        var serializedValue = JsonSerializer.Deserialize<TEntity>(value);
                        entities.Add(serializedValue);
                    }
                }
            }

            redis.Close();

            return entities;
        }

        public void Dispose()
        {
            redis.Close();
        }
    }
}
