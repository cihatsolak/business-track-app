using AutoMapper;
using BusinessTrack.Entities.Concrete;
using BusinessTrack.Entities.Concrete.Helpers;
using BusinessTrack.Web.Models.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BusinessTrack.Web.Factories
{
    public partial class AppUserModelFactory : IAppUserModelFactory
    {
        private readonly IMapper _mapper;
        public AppUserModelFactory(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<AppUser> PrepareAdminAppUserEntity(AppUserViewModel appUserViewModel = null, AppUser appUser = null)
        {
            if (appUserViewModel == null)
                throw new ArgumentNullException(nameof(appUserViewModel));

            if (appUser == null)
                throw new ArgumentNullException(nameof(appUser));

            if (appUserViewModel.ProfilePictureFile != null)
            {
                var pictureFileExtension = Path.GetExtension(appUserViewModel.ProfilePictureFile.FileName);
                string pictureName = $"{Guid.NewGuid()}{pictureFileExtension}";

                var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/img/{pictureName}");

                using (var stream = new FileStream(path, FileMode.Create))
                    await appUserViewModel.ProfilePictureFile.CopyToAsync(stream);

                appUser.Picture = pictureName;
            }

            appUser.Name = appUserViewModel.Name;
            appUser.Surname = appUserViewModel.Surname;
            appUser.Email = appUserViewModel.Email;

            return appUser;
        }
        public AppUserViewModel PrepareAppUserViewModel(AppUser appUser = null)
        {
            if (appUser == null)
                throw new ArgumentNullException(nameof(appUser));

            var appUserViewModel = _mapper.Map<AppUserViewModel>(appUser);
            appUserViewModel.Picture = $"/img/{appUser.Picture}";

            return appUserViewModel;
        }

        public AppUserWrapperModel PrepareAppUserWrapperModel(AppUser appUser = null)
        {
            if (appUser == null)
                throw new ArgumentNullException(nameof(appUser));

            var appUserWrapperModel = new AppUserWrapperModel
            {
                FullName = $"{appUser.Name} {appUser.Surname}",
                Email = appUser.Email,
                Picture = $"/img/{appUser.Picture}"
            };

            return appUserWrapperModel;
        }

        public string PrepareDualHelperListJsonModel(List<DualHelper> dualHelpers = null)
        {
            return JsonConvert.SerializeObject(dualHelpers);
        }

        public AppUser PrepareWebAppUserEntity(AppUserViewModel appUserViewModel = null)
        {
            if (appUserViewModel == null)
                throw new ArgumentNullException(nameof(appUserViewModel));

            var user = _mapper.Map<AppUser>(appUserViewModel);
            return user;
        }
    }
}
