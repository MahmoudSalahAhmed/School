using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ViewModels
{
    public static class AdminExtensions
    {
        public static AdminEditViewModel ToEditableViewModel(this Admin model)
        {
            return new AdminEditViewModel
            {
                ID = model.ID,
                Password = model.Password,
                User = model.User.ToEditableViewModel()
            };
        }
        public static Admin ToModel(this AdminEditViewModel EditModel)
        {
            return new Admin()
            {
                ID = EditModel.ID,
                Password = EditModel.Password,
                User = EditModel.User.ToModel()
            };
        }
        public static AdminViewModel ToViewModel(this Admin Model)
        {
            return new AdminViewModel()
            {
                ID = Model.ID,
                Password = Model.Password,
                User = Model.User.ToViewModel()
            };
        }
    }
}
