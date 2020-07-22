using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public static class SubjectExtensions
    {
        public static SubjectViewModel ToViewModel(this Subject Model)
        {
            return new SubjectViewModel()
            {
                ID = Model.ID,
                Name = Model.Name
            };
        }
        public static Subject ToModel(this SubjectEditViewModel EditModel)
        {
            return new Subject()
            {
                ID = EditModel.ID,
                Name = EditModel.Name
            };
        }
        public static SubjectEditViewModel ToEditableViewModel(this Subject Model)
        {
            return new SubjectEditViewModel()
            {
                ID = Model.ID,
                Name = Model.Name
            };
        }
    }
}
