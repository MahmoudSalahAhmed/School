using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Teacher :BaseModel
    {
        public virtual User User { get; set; }
        public virtual ICollection<ScheduleLesson> ScheduleLessons { get; set; }
    }
}
