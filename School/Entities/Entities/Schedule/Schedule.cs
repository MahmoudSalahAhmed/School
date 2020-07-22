using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Schedule : BaseModel
    {
        public virtual ClassRoom ClassRoom { get; set; }
        public int ClassRoomID { get; set; }
        public virtual Day Day { get; set; }
        public int DayID { get; set; }
        public virtual ICollection<ScheduleLesson> ScheduleLessons { get; set; }
    }
}
