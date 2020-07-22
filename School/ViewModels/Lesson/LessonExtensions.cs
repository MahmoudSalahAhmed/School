using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public static class LessonExtensions
    {
        public static LessonViewModel ToViewModel(this Lesson Model)
        {
            return new LessonViewModel()
            {
                ID = Model.ID,
                Name = Model.Name
            };
        }
        public static Lesson ToModel(this LessonEditViewModel EditModel)
        {
            return new Lesson()
            {
                ID = EditModel.ID,
                Name = EditModel.Name
            };
        }
        public static LessonEditViewModel ToEditableViewModel(this Lesson Model)
        {
            return new LessonEditViewModel()
            {
                ID = Model.ID,
                Name = Model.Name
            };
        }
    }
}
