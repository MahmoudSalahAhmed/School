using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public static class ScheduleLessonLessonExtentions
    {
        public static ScheduleLessonViewModel ToViewModel(this ScheduleLesson Model)
        {
            return new ScheduleLessonViewModel()
            {
                ID = Model.ID,
                ScheduleID = Model.ScheduleID,
                TeacherID = Model.TeacherID,
                LessonID = Model.LessonID,
                SubjectID = Model.SubjectID,
                Subject = Model.Subject.ToViewModel(),
                Schedule = Model.Schedule.ToViewModel(),
                Teacher = Model.Teacher.ToViewModel(),
                Lesson = Model.Lesson.ToViewModel(),
            };
        }
        public static ScheduleLessonEditViewModel ToEditableViewModel(this ScheduleLesson Model)
        {
            return new ScheduleLessonEditViewModel()
            {
                ID = Model.ID,
                SubjectID = Model.SubjectID,
                TeacherID = Model.TeacherID,
                ScheduleID = Model.ScheduleID,
                LessonID = Model.LessonID,
            };
        }
        public static ScheduleLesson ToModel(this ScheduleLessonEditViewModel EditModel)
        {
            return new ScheduleLesson()
            {
                ID = EditModel.ID,
                TeacherID = EditModel.TeacherID,
                LessonID = EditModel.LessonID,
                ScheduleID = EditModel.ScheduleID,
                SubjectID = EditModel.SubjectID,
            };
        }
    }
}
