using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ScheduleLessonViewModel
    {
        public int ID { get; set; }
        public int LessonID { get; set; }
        public int TeacherID { get; set; }
        public int SubjectID { get; set; }
        public int ScheduleID { get; set; }
        public SubjectViewModel Subject { get; set; }
        public TeacherViewModel Teacher { get; set; }
        public LessonViewModel Lesson { get; set; }
        public ScheduleViewModel Schedule { get; set; }

    }
}
