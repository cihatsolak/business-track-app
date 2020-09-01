using BusinessTrack.Entities.Interfaces;
using System.Collections.Generic;

namespace BusinessTrack.Business.Interfaces
{
    public interface IGenericService<TEntity> where TEntity : class, IEntity, new()
    {
        List<TEntity> GetAll();
        TEntity GetById(int id);
        void Insert(TEntity entity);
        void Insert(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(IEnumerable<TEntity> entities);
    }
}
