using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class ScheduleLessonConfiguration : EntityTypeConfiguration<ScheduleLesson>
    {
        public ScheduleLessonConfiguration()
        {
            ToTable("ScheduleLesson");

            HasRequired(i => i.Teacher).WithMany(i => i.ScheduleLessons).
                HasForeignKey(i => i.TeacherID);

            HasRequired(i => i.Schedule).WithMany(i => i.ScheduleLessons).
                HasForeignKey(i => i.ScheduleID);

            HasRequired(i => i.Lesson).WithMany(i => i.ScheduleLessons).
               HasForeignKey(i => i.LessonID);

            HasRequired(i => i.Subject).WithMany(i => i.ScheduleLessons).
               HasForeignKey(i => i.SubjectID);
        }
    }
}
