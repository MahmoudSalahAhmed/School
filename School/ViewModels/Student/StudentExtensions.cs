using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public static class StudentExtensions
    {
        public static StudentViewModel ToViewModel(this Student Model)
        {
            return new StudentViewModel()
            {
                ID = Model.ID,
                ClassRoomID = Model.ClassRoomID,
                User = Model.User.ToViewModel(),
                ClassRoom = Model.ClassRoom.ToViewModel()

            };
        }
        public static StudentEditViewModel ToEditableViewModel(this Student Model)
        {
            return new StudentEditViewModel()
            {
                ID = Model.ID,
                ClassRoomID = Model.ClassRoomID,
                User = Model.User.ToEditableViewModel()
            };
        }
        public static Student ToModel(this StudentEditViewModel EditModel)
        {
            return new Student()
            {
                ID = EditModel.ID,
                ClassRoomID = EditModel.ClassRoomID,
                User = EditModel.User.ToModel(),
            };
        }

    }
}
