using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class LessonConfiguration : EntityTypeConfiguration<Lesson>
    {
        public LessonConfiguration()
        {
            ToTable("Lesson");
            Property(i => i.Name).HasMaxLength(50).IsRequired();
         
            HasMany(i => i.ScheduleLessons).WithRequired(i => i.Lesson);
        }
    }
}
