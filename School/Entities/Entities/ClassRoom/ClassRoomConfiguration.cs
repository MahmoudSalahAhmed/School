using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class ClassRoomConfiguration : EntityTypeConfiguration<ClassRoom>
    {
        public ClassRoomConfiguration()
        {
            ToTable("ClassRoom");
            Property(i => i.Name).HasMaxLength(40).IsRequired();
            
            HasMany(i => i.Students).WithRequired(i => i.ClassRoom).WillCascadeOnDelete(false);
            HasMany(i => i.Schedules).WithRequired(i => i.ClassRoom).WillCascadeOnDelete(false); ;

        }
    }
}
