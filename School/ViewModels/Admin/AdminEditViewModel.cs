using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class AdminEditViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; }
        public UserEditViewModel User { get; set; }
    }
}
