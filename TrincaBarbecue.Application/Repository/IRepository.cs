﻿using TrincaBarbecue.Core.Aggregate;

namespace TrincaBarbecue.Application.Repository
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        TEntity? Get(Guid identifier);
        void Add(TEntity entity);
        TEntity Find(Predicate<TEntity> action);
        void Update(TEntity entity);
    }
}
