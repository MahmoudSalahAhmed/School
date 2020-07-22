using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class SubjectConfiguration : EntityTypeConfiguration<Subject>
    {
        public SubjectConfiguration()
        {
            ToTable("Subject");
            Property(i => i.Name).HasMaxLength(50).IsRequired();
            HasMany(i => i.ScheduleLessons).WithRequired(i => i.Subject);
        }
    }
}
