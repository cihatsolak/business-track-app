using BusinessTrack.Business.Interfaces;
using BusinessTrack.DataAccess.Interfaces;
using BusinessTrack.Entities.Concrete;
using System.Collections.Generic;

namespace BusinessTrack.Business.Concrete
{
    public class LoggerManager : ILoggerService
    {
        private readonly ILoggerDal _loggerDal;
        public LoggerManager(ILoggerDal loggerDal)
        {
            _loggerDal = loggerDal;
        }
       
        public List<Log> GetAll()
        {
            return _loggerDal.GetAll();
        }

        public Log GetById(int id)
        {
            return _loggerDal.GetById(id);
        }

        public void Insert(Log entity)
        {
            _loggerDal.Insert(entity);
        }

        public void Insert(IEnumerable<Log> entities)
        {
            _loggerDal.Insert(entities);
        }

        public void Update(Log entity)
        {
            _loggerDal.Update(entity);
        }

        public void Delete(Log entity)
        {
            _loggerDal.Delete(entity);
        }

        public void Delete(IEnumerable<Log> entities)
        {
            _loggerDal.Delete(entities);
        }
    }
}
