using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public static class TeacherExtensions
    {
        
            public static TeacherViewModel ToViewModel(this Teacher Model)
            {
                return new TeacherViewModel()
                {
                    ID = Model.ID,
                    User = Model.User.ToViewModel()
                };
            }
            public static TeacherEditViewModel ToEditableViewModel(this Teacher Model)
            {
                return new TeacherEditViewModel()
                {
                    ID = Model.ID,
                    User = Model.User.ToEditableViewModel()
                };
            }
            public static Teacher ToModel(this TeacherEditViewModel EditModel)
            {
                return new Teacher()
                {
                    ID = EditModel.ID,
                    User =EditModel.User.ToModel()
                };
            }
        
    }
}
