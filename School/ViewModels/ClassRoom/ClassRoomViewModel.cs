using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ClassRoomViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IEnumerable<StudentViewModel> Students { get; set; }
        public IEnumerable<ScheduleViewModel> Schedules { get; set; }

    }
}
