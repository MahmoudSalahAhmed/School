using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ScheduleViewModel
    {
        public int ID { get; set; }
       
        public int ClassRoomID { get; set; }
        public ClassRoomViewModel ClassRoom { get; set; }
        public int DayID { get; set; }
        public DayViewModel Day { get; set; }
        public IEnumerable<ScheduleLessonViewModel> ScheduleLessons { get; set; }

    }
}
