using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public static class ScheduleExtentions
    {
        public static ScheduleViewModel ToViewModel(this Schedule Model)
        {
            return new ScheduleViewModel()
            {
                ID = Model.ID,
                ClassRoomID = Model.ClassRoomID,
                DayID = Model.DayID,
                ClassRoom = Model.ClassRoom.ToViewModel(),
                Day = Model.Day.ToViewModel(),
                ScheduleLessons = Model.ScheduleLessons?.Select(i => i.ToViewModel())
            };
        }
        public static ScheduleEditViewModel ToEditableViewModel(this Schedule Model)
        {
            return new ScheduleEditViewModel()
            {
                ID = Model.ID,
                ClassRoomID = Model.ClassRoomID,
                DayID = Model.DayID,
            };
        }
        public static Schedule ToModel(this ScheduleEditViewModel EditModel)
        {
            return new Schedule()
            {
                ID = EditModel.ID,
                ClassRoomID = EditModel.ClassRoomID,
                DayID = EditModel.DayID,
            };
        }
    }
}
