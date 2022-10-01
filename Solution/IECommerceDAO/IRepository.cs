using ECommerceModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace IECommerceDAO
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity FindById(object id);
        List<TEntity> GetList();
        bool Insert(TEntity entity);
        bool InsertIfDoesNotExist(TEntity entity);
        bool Delete(object id);
        bool Update(TEntity entityToUpdate);
    }
}
