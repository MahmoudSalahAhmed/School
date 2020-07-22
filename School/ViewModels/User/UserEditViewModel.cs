using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class UserEditViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = "InValid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone Is Required")]
        [Phone(ErrorMessage = "InValid Phone Number")]
        public string Phone { get; set; }
    }
}
