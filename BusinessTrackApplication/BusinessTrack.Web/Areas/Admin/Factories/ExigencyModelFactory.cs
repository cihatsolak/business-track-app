using AutoMapper;
using BusinessTrack.Entities.Concrete;
using BusinessTrack.Web.Areas.Admin.Models.Exigencies;
using System;
using System.Collections.Generic;

namespace BusinessTrack.Web.Areas.Admin.Factories
{
    public class ExigencyModelFactory : IExigencyModelFactory
    {
        private readonly IMapper _mapper;
        public ExigencyModelFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Exigency PrepareExigencyEntity(ExigencyViewModel exigencyViewModel = null)
        {
            if (exigencyViewModel == null)
                throw new ArgumentNullException(nameof(exigencyViewModel));

            var exigency = _mapper.Map<Exigency>(exigencyViewModel);
            return exigency;
        }

        public ExigencyListViewModel PrepareExigencyListviewModel(List<Exigency> exigencies = null)
        {
            if (exigencies == null)
                throw new ArgumentNullException(nameof(exigencies));

            var exigencyListViewModel = new ExigencyListViewModel();

            foreach (var exigency in exigencies)
            {
                var exigencyViewModels = _mapper.Map<ExigencyViewModel>(exigency);
                exigencyListViewModel.ExigencyViewModels.Add(exigencyViewModels);
            }

            return exigencyListViewModel;
        }

        public ExigencyViewModel PrepareExigencyViewModel(Exigency exigency = null)
        {
            if (exigency == null)
                throw new ArgumentNullException(nameof(exigency));

            var exigencyViewModel = _mapper.Map<ExigencyViewModel>(exigency);
            return exigencyViewModel;
        }
    }
}
