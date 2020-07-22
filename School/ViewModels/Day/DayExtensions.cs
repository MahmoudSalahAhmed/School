using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public static class DayExtentions
    {
        public static DayViewModel ToViewModel(this Day Model)
        {
            return new DayViewModel()
            {
                ID = Model.ID,
                Name = Model.Name,
                
            };
        }
        public static DayEditViewModel ToEditableViewModel(this Day Model)
        {
            return new DayEditViewModel()
            {
                ID = Model.ID,
                Name = Model.Name,
           
            };
        }
        public static Day ToModel(this DayEditViewModel EditModel)
        {
            return new Day()
            {
                ID = EditModel.ID,
                Name = EditModel.Name,
                
            };
        }
    }
}
