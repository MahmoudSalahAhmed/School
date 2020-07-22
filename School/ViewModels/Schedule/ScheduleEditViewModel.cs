using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ScheduleEditViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "ClassRoomID Is Required")]
        public int ClassRoomID { get; set; }
        [Required(ErrorMessage = "DayID Is Required")]
        public int DayID { get; set; }
    }
}
