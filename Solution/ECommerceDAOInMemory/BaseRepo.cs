using ECommerceModel;
using ECommerceModel.Helpers;
using IECommerceDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerceDAOInMemory
{
    public abstract class BaseRepo<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        public bool Delete(object id)
        {
            return ECommerceDatabase.Instance.Set<TEntity>().TryRemove(id, out _);
        }

        public TEntity FindById(object id)
        {
            if (ECommerceDatabase.Instance.Set<TEntity>().TryGetValue(id, out TEntity entity))
            {
                return (TEntity)entity;
            }
            return EmptyEntityBuilder.Instance.GetEmptyEntity<TEntity>();
        }

        public List<TEntity> GetList()
        {
            return ECommerceDatabase.Instance.Set<TEntity>().Values.ToList();
        }

        public bool Insert(TEntity entity)
        {
            return ECommerceDatabase.Instance.Set<TEntity>().TryAdd(entity.GetId(), entity);
        }

        public bool InsertIfDoesNotExist(TEntity entity)
        {
            TEntity t = FindById(entity.GetId());
            if (t == null)
            {
                return Insert(entity);
            }
            return false;
        }

        public bool Update(TEntity entityToUpdate)
        {
            object id = entityToUpdate.GetId();
            if (ECommerceDatabase.Instance.Set<TEntity>().TryGetValue(id, out TEntity e))
            {
                return ECommerceDatabase.Instance.Set<TEntity>().TryUpdate(entityToUpdate.GetId(), entityToUpdate, e);
            }
            return false;
        }
    }
}
