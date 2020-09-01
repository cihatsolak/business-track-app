using BusinessTrack.Business.Interfaces;
using BusinessTrack.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using BusinessTrack.DataAccess.Interfaces;
using BusinessTrack.Entities.Concrete;
using System.Collections.Generic;

namespace BusinessTrack.Business.Concrete
{
    public class ExigencyManager : IExigencyService
    {
        readonly IExigencyDal _exigencyDal;
        public ExigencyManager(IExigencyDal exigencyDal)
        {
            _exigencyDal = exigencyDal;
        }
        public List<Exigency> GetAll()
        {
            return _exigencyDal.GetAll();
        }

        public Exigency GetById(int id)
        {
            return _exigencyDal.GetById(id);
        }

        public void Insert(Exigency entity)
        {
            _exigencyDal.Insert(entity);
        }

        public void Insert(IEnumerable<Exigency> entities)
        {
            _exigencyDal.Insert(entities);
        }

        public void Update(Exigency entity)
        {
            _exigencyDal.Update(entity);
        }

        public void Delete(Exigency entity)
        {
            _exigencyDal.Delete(entity);
        }

        public void Delete(IEnumerable<Exigency> entities)
        {
            _exigencyDal.Delete(entities);
        }

    }
}
