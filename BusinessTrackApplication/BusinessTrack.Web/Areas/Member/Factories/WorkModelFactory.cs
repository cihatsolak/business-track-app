using AutoMapper;
using BusinessTrack.Entities.Concrete;
using BusinessTrack.Web.Areas.Member.Models.Reports;
using BusinessTrack.Web.Areas.Member.Models.Works;
using System;
using System.Collections.Generic;

namespace BusinessTrack.Web.Areas.Member.Factories
{
    public class WorkModelFactory : IWorkModelFactory
    {
        private readonly IMapper _mapper;
        public WorkModelFactory(IMapper mapper)
        {
            _mapper = mapper;
        }
        public AssignedJobListViewModel PrepareAssignedJobListViewModel(List<Assignment> assignments = null)
        {
            if (assignments == null)
                throw new ArgumentNullException(nameof(assignments));

            var assignedJobListViewModel = new AssignedJobListViewModel();

            foreach (var assignment in assignments)
            {
                var assignedJobViewModel = new AssignedJobViewModel
                {
                    Id = assignment.Id,
                    Name = assignment.Name,
                    ExigencyDefinition = assignment.Exigency.Definition,
                    Description = assignment.Description,
                    ReportCount = assignment.Reports.Count
                };


                foreach (var report in assignment.Reports)
                {
                    var reportViewModel = _mapper.Map<ReportViewModel>(report);
                    assignedJobViewModel.Reports.Add(reportViewModel);
                }

                assignedJobListViewModel.AssignedJobs.Add(assignedJobViewModel);
            }

            return assignedJobListViewModel;
        }
    }
}
