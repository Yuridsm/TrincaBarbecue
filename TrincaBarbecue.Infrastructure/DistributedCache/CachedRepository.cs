using StackExchange.Redis;
using System.Text.Json;
using TrincaBarbecue.Core.Aggregate.Participant;
using TrincaBarbecue.Infrastructure.JsonConverters;
using TrincaBarbecue.SharedKernel.Interfaces;

namespace TrincaBarbecue.Infrastructure.DistributedCache
{
    public class CachedRepository : ICachedRepository, IDisposable
    {
        private readonly IDatabase _distributedCache;
        private readonly ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379");

        public CachedRepository()
        {
            _distributedCache = redis.GetDatabase();
        }

        public TEntity? Get<TEntity>(string key) where TEntity : IEntity<Guid>, IAggregateRoot
        {
            var output = _distributedCache.ListRange($"{typeof(TEntity).Name.ToUpper()}-{key}", 0, -1);

            if (output.Length == 0) return default(TEntity);

            if (typeof(TEntity) == typeof(Participant))
            {
                var options = new JsonSerializerOptions();

                options.Converters.Add(new ParticipantConverter());

                return JsonSerializer.Deserialize<TEntity>(output[0], options);
            }
            else
            {
                return JsonSerializer.Deserialize<TEntity>(output[0]);
            }
        }

        public long Delete<TEntity>(string key, string value) where TEntity : IEntity<Guid>, IAggregateRoot
        {
            return _distributedCache.ListRemove($"{typeof(TEntity).Name.ToUpper()}-{key}", value);
        }

        public bool DeleteList<TEntity>(string key) where TEntity : IEntity<Guid>, IAggregateRoot
        {
            return _distributedCache.KeyDelete($"{typeof(TEntity).Name.ToUpper()}-{key}");
        }

        public void Set<TEntity>(string key, TEntity value) where TEntity : IEntity<Guid>, IAggregateRoot
        {
            var input = JsonSerializer.Serialize(value);
            _distributedCache.ListRightPush($"{typeof(TEntity).Name.ToUpper()}-{key}", input);
        }

        public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : IEntity<Guid>, IAggregateRoot
        {
            var redis = ConnectionMultiplexer.Connect("localhost:6379");
            ICollection<TEntity> entities = new List<TEntity>();

            RedisKey[] keys = redis
                .GetServer("localhost:6379")
                .Keys(pattern: $"{typeof(TEntity).Name.ToUpper()}-*")
                .ToArray();

            foreach (var key in keys)
            {
                RedisValue[] values = _distributedCache.ListRange(key);

                foreach (RedisValue value in values)
                {
                    if (typeof(TEntity) == typeof(Participant))
                    {
                        var options = new JsonSerializerOptions();

                        options.Converters.Add(new ParticipantConverter());

                        var serializedValue = JsonSerializer.Deserialize<TEntity>(value, options);
                        entities.Add(serializedValue);
                    }
                    else
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
