﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class TeacherEditViewModel
    {
        public int ID { get; set; }
        public UserEditViewModel User { get; set; }
    }
}
