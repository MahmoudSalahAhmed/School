using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class ScheduleLesson : BaseModel
    {
        public virtual Teacher Teacher { get; set; }
        public int TeacherID { get; set; }
        public virtual Schedule Schedule { get; set; }
        public int ScheduleID { get; set; }
        public virtual Subject Subject { get; set; }
        public int SubjectID { get; set; }

        public virtual Lesson Lesson { get; set; }
        public int LessonID { get; set; }
    }
}
