using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using StackExchange.Redis;
using System.Text.Json;
using TrincaBarbecue.SharedKernel.Interfaces;

namespace TrincaBarbecue.Infrastructure.DistributedCache
{
    public class CachedRepository<TEntity> : ICachedRepository<TEntity>
        where TEntity : IEntity<Guid>, IAggregateRoot
    {
        private readonly IDistributedCache _distributedCache;

        public CachedRepository(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public TEntity Get(string key)
        {
            var output = _distributedCache.Get(key);
            return JsonSerializer.Deserialize<TEntity>(output);
        }

        public void Set(string key, TEntity value)
        {
            var input = JsonSerializer.Serialize(value);
            _distributedCache.SetString(key, input);
        }

        IEnumerable<TEntity> ICachedRepository<TEntity>.GetAll()
        {
            var redis = ConnectionMultiplexer.Connect("localhost");
            ICollection<TEntity> entities = new List<TEntity>();

            var distributedCache = new RedisCache(new RedisCacheOptions
            {
                Configuration = "localhost:6379",
                InstanceName = "redisinstance"
            });

            var server = redis.GetServer("localhost", 6379);
            var keys = server.Keys();

            foreach (var key in keys)
            {
                var value = distributedCache.Get(key);

                var serializedValue = JsonSerializer.Deserialize<TEntity>(value);
                entities.Add(serializedValue);
            }

            redis.Close();

            return entities;
        }
    }
}
