using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class StudentViewModel
    {
        public int ID { get; set; }
        public int ClassRoomID { get; set; }
        public UserViewModel User { get; set; }
        public ClassRoomViewModel ClassRoom { get; set; }

    }
}
