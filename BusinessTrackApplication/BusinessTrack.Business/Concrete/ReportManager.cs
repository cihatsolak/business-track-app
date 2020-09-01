using BusinessTrack.Business.Interfaces;
using BusinessTrack.DataAccess.Interfaces;
using BusinessTrack.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessTrack.Business.Concrete
{
    public class ReportManager : IReportService
    {
        readonly IReportDal _reportDal;
        public ReportManager(IReportDal reportDal)
        {
            _reportDal = reportDal;
        }

        public List<Report> GetAll()
        {
            return _reportDal.GetAll();
        }

        public Report GetById(int id)
        {
            return _reportDal.GetById(id);
        }

        public void Insert(Report entity)
        {
            _reportDal.Insert(entity);
        }

        public void Insert(IEnumerable<Report> entities)
        {
            _reportDal.Insert(entities);
        }

        public void Update(Report entity)
        {
            _reportDal.Update(entity);
        }

        public void Delete(Report entity)
        {
            _reportDal.Delete(entity);
        }

        public void Delete(IEnumerable<Report> entities)
        {
            _reportDal.Delete(entities);
        }

        public List<Report> GetReportsByAssignmentId(int id)
        {
            return _reportDal.GetReportsByAssignmentId(id);
        }

        public Report GetReportWithAssignment(int id)
        {
            return _reportDal.GetReportWithAssignment(id);
        }

        public int GetReportCountByUserId(int id)
        {
            return _reportDal.GetReportCountByUserId(id);
        }

        public int GetAllReportCount()
        {
           return _reportDal.GetAllReportCount();
        }
    }
}
