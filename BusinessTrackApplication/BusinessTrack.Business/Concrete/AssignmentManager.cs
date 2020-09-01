using BusinessTrack.Business.Interfaces;
using BusinessTrack.DataAccess.Interfaces;
using BusinessTrack.Entities.Concrete;
using System.Collections.Generic;

namespace BusinessTrack.Business.Concrete
{
    public class AssignmentManager : IAssignmentService
    {
        private readonly IAssignmentDal _assignmentDal;
        public AssignmentManager(IAssignmentDal assignmentDal)
        {
            _assignmentDal = assignmentDal;
        }

        public List<Assignment> GetAll()
        {
            return _assignmentDal.GetAll();
        }

        public Assignment GetById(int id)
        {
            return _assignmentDal.GetById(id);
        }

        public void Insert(Assignment entity)
        {
            _assignmentDal.Insert(entity);
        }

        public void Insert(IEnumerable<Assignment> entities)
        {
            _assignmentDal.Insert(entities);
        }

        public void Update(Assignment entity)
        {
            _assignmentDal.Update(entity);
        }

        public void Delete(Assignment entity)
        {
            _assignmentDal.Delete(entity);
        }

        public void Delete(IEnumerable<Assignment> entities)
        {
            _assignmentDal.Delete(entities);
        }

        public List<Assignment> GetIncompleteAssignmentWithExigency()
        {
            return _assignmentDal.GetIncompleteAssignmentWithExigency();
        }

        public List<Assignment> GetAllWithAssociatedTables()
        {
            return _assignmentDal.GetAllWithAssociatedTables();
        }

        public Assignment GetAssignmentWithExigencyById(int id)
        {
            return _assignmentDal.GetAssignmentWithExigencyById(id);
        }

        public List<Assignment> GetAssignmentsByUserId(int userId)
        {
            return _assignmentDal.GetAssignmentsByUserId(userId);
        }

        public Assignment GetAssignmentWithReports(int id)
        {
            return _assignmentDal.GetAssignmentWithReports(id);
        }

        public List<Assignment> GetAllWithAssociatedTablesByUserId(int userId)
        {
            return _assignmentDal.GetAllWithAssociatedTablesByUserId(userId);
        }

        public List<Assignment> GetAllInCompleteWithRelationships(out int totalPageCount, int userId, int pageIndex)
        {
            return _assignmentDal.GetAllInCompleteWithRelationships(out totalPageCount, userId, pageIndex);
        }

        public int GetCompletedTaskCountByUserId(int id)
        {
            return _assignmentDal.GetCompletedTaskCountByUserId(id);
        }

        public int GetInCompletedTaskCountByUserId(int id)
        {
            return _assignmentDal.GetInCompletedTaskCountByUserId(id);
        }

        public int GetUnAssignedTaskCount()
        {
            return _assignmentDal.GetUnAssignedTaskCount();
        }

        public int GetCompletedTaskCount()
        {
            return _assignmentDal.GetCompletedTaskCount();
        }
    }
}
