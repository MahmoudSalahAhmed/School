using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public static class UserExtensions
    {
        public static UserViewModel ToViewModel(this User Model)
        {
            return new UserViewModel()
            {
                ID = Model.ID,
                Name = Model.Name,
                Email = Model.Email,
                Phone = Model.Phone,
            };
        }
        public static User ToModel(this UserEditViewModel EditModel)
        {
            return new User()
            {
                ID = EditModel.ID,
                Name = EditModel.Name,
                Email = EditModel.Email,
                Phone = EditModel.Phone,
            };
        }
        public static UserEditViewModel ToEditableViewModel(this User Model)
        {
            return new UserEditViewModel()
            {
                ID = Model.ID,
                Name = Model.Name,
                Email = Model.Email,
                Phone = Model.Phone,
            };
        }
    }
}
