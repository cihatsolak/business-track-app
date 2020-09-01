using BusinessTrack.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using BusinessTrack.DataAccess.Interfaces;
using BusinessTrack.Entities.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BusinessTrack.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class, IEntity, new()
    {
        public List<TEntity> GetAll()
        {
            using var context = new BusinessTrackContext();
            return context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            using var context = new BusinessTrackContext();
            return context.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity entity)
        {
            using var context = new BusinessTrackContext();
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            using var context = new BusinessTrackContext();
            context.Set<TEntity>().AddRange(entities);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            using var context = new BusinessTrackContext();
            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            using var context = new BusinessTrackContext();
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            using var context = new BusinessTrackContext();
            context.Set<TEntity>().RemoveRange(entities);
            context.SaveChanges();
        }
    }
}
