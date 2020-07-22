using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class TeacherConfiguration : EntityTypeConfiguration<Teacher>
    {
        public TeacherConfiguration()
        {
            ToTable("Teacher");

            HasRequired(i => i.User).WithMany().HasForeignKey(i => i.ID);

            HasMany(i => i.ScheduleLessons).WithRequired(i => i.Teacher);


        }
    }
}
