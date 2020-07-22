using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class StudentConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentConfiguration()
        {
            ToTable("Student");
            
            HasRequired(i => i.ClassRoom).WithMany(i => i.Students).
                   HasForeignKey(i => i.ClassRoomID);

            HasRequired(i => i.User).WithMany().HasForeignKey(i => i.ID);
        }
    }
}
