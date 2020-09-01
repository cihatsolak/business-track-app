using AutoMapper;
using BusinessTrack.Entities.Concrete;
using BusinessTrack.Web.Areas.Admin.Models.Assignments;
using BusinessTrack.Web.Areas.Admin.Models.Reports;
using BusinessTrack.Web.Models.Users;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace BusinessTrack.Web.Areas.Admin.Factories
{
    public class AssignmentModelFactory : IAssignmentModelFactory
    {
        private readonly IMapper _mapper;
        public AssignmentModelFactory(IMapper mapper)
        {
            _mapper = mapper;
        }
        public AssignmentAppUserViewModel PrepareAssignmentAppUserViewModel(Assignment assignment = null, List<AppUser> users = null, int pageIndex = 1, int totalCount = 1)
        {
            if (assignment == null)
                throw new ArgumentNullException(nameof(assignment));

            if (users == null)
                throw new ArgumentNullException(nameof(assignment));

            var assignmentAppUserViewModel = new AssignmentAppUserViewModel
            {
                Id = assignment.Id,
                Name = assignment.Name,
                Definition = assignment.Exigency.Definition,
                Description = assignment.Description,
                CreatedOn = assignment.CreatedOn.ToString()
            };

            foreach (var user in users)
            {
                var appUserViewModel = new AppUserViewModel
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    Picture = $"/img/{user.Picture}"
                };

                assignmentAppUserViewModel.AppUsers.Add(appUserViewModel);
            }

            assignmentAppUserViewModel.ActivePage = pageIndex;
            assignmentAppUserViewModel.TotalPage = (int)Math.Ceiling((double)totalCount / 3);

            return assignmentAppUserViewModel;
        }

        public Assignment PrepareAssignmentEntity(AssignmentViewModel assignmentViewModel = null)
        {
            if (assignmentViewModel == null)
                throw new ArgumentNullException(nameof(assignmentViewModel));

            var assignment = _mapper.Map<Assignment>(assignmentViewModel);
            assignment.CreatedOn = DateTime.Now;

            return assignment;
        }

        public List<AssignmentListAllViewModel> PrepareAssignmentListAllViewModel(List<Assignment> assignments = null)
        {
            if (assignments == null)
                throw new ArgumentNullException(nameof(assignments));

            var assignmentListAllViewModel = new List<AssignmentListAllViewModel>();

            foreach (var assignment in assignments)
            {
                var model = new AssignmentListAllViewModel
                {
                    Id = assignment.Id,
                    Name = assignment.Name,
                    Description = assignment.Description,
                    CreatedOn = assignment.CreatedOn.ToString(),

                    ExigencyDefinition = assignment.Exigency.Definition
                };

                if (assignment.AppUser != null)
                    model.AppUserFullName = $"{assignment.AppUser.Name} {assignment.AppUser.Surname}";

                model.ReportCount = assignment.Reports.Count;

                assignmentListAllViewModel.Add(model);
            }

            return assignmentListAllViewModel;
        }

        public AssignmentListViewModel PrepareAssignmentListViewModel(List<Assignment> assignments = null)
        {
            if (assignments == null)
                throw new ArgumentNullException(nameof(assignments));

            var assignmentListViewModel = new AssignmentListViewModel();

            foreach (var assignment in assignments)
            {
                var model = new AssignmentViewModel
                {
                    Id = assignment.Id,
                    Name = assignment.Name,
                    Description = assignment.Description,
                    Status = assignment.Status,
                    CreatedOn = assignment.CreatedOn.ToString(),

                    ExigencyId = assignment.ExigencyId,
                    ExigencyDefinition = assignment.Exigency.Definition
                };

                assignmentListViewModel.AssignmemtsViewModel.Add(model);
            }

            return assignmentListViewModel;
        }

        public AssignmentReportsViewModel PrepareAssignmentReportsViewModel(Assignment assignment = null)
        {
            if (assignment == null)
                throw new ArgumentNullException(nameof(assignment));

            var model = new AssignmentReportsViewModel
            {
                Id = assignment.Id,
                Name = assignment.Name,
                Description = assignment.Description,
                UserFullName = $"{assignment.AppUser.Name} {assignment.AppUser.Surname}"
            };

            if (assignment.Reports != null && assignment.Reports.Count > 0)
            {
                foreach (var report in assignment.Reports)
                {
                    var reportViewModel = _mapper.Map<ReportViewModel>(report);
                    model.ReportsViewModel.Add(reportViewModel);
                }
            }

            return model;
        }

        public AssignmentViewModel PrepareAssignmentViewModel(List<Exigency> exigencies = null, Assignment assignment = null)
        {
            if (exigencies == null)
                throw new ArgumentNullException(nameof(exigencies));

            var assignmentViewModel = new AssignmentViewModel();

            if (assignment != null)
            {
                assignmentViewModel.Name = assignment.Name;
                assignmentViewModel.Id = assignment.Id;
                assignmentViewModel.Description = assignment.Description;
            }
            else
            {
                assignmentViewModel.Exigencies.Add(new SelectListItem
                {
                    Text = "Aciliyet seçiniz",
                    Value = "-1"
                });
            }

            foreach (var exigency in exigencies)
            {
                assignmentViewModel.Exigencies.Add(new SelectListItem
                {
                    Value = exigency.Id.ToString(),
                    Text = exigency.Definition,
                    Selected = exigency.Id == assignment?.ExigencyId
                });
            }

            return assignmentViewModel;
        }

        public AssignmentViewModel PrepareAssignmentViewModel(Assignment assignment = null)
        {
            if (assignment == null)
                throw new ArgumentNullException(nameof(assignment));

            var assignmentViewModel = new AssignmentViewModel
            {
                Id = assignment.Id,
                Name = assignment.Name,
                Description = assignment.Description,
                ExigencyId = assignment.Exigency.Id,
                ExigencyDefinition = assignment.Exigency.Definition,
                CreatedOn = assignment.CreatedOn.ToString()
            };

            return assignmentViewModel;
        }

        public AssignUserViewModel PrepareAssignUserViewModel(AppUser user = null, Assignment assignment = null)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (assignment == null)
                throw new ArgumentNullException(nameof(assignment));

            var model = new AssignUserViewModel
            {
                UserId = user.Id,
                UserFullName = $"{user.Name} {user.Surname}",
                UserPicture = $"/img/{user.Picture}",
                UserEmail = user.Email,

                AssignmentId = assignment.Id,
                AssignmentDescription = assignment.Description,
                AssignmentExigencyDefinition = assignment.Exigency.Definition,
                AssignmentName = assignment.Name
            };

            return model;
        }
    }
}
