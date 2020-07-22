using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Day : BaseModel
    {
        public string Name { get; set; }
        
        public virtual ICollection<Schedule> Schedules { get; set; }
        

    }
}
