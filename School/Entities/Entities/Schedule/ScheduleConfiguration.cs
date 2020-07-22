using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class ScheduleConfiguration : EntityTypeConfiguration<Schedule>
    {
        public ScheduleConfiguration()
        {
            ToTable("Schedule");

            HasRequired(i => i.ClassRoom).WithMany(i => i.Schedules).
                HasForeignKey(i => i.ClassRoomID);
            HasRequired(i => i.Day).WithMany(i => i.Schedules).
                HasForeignKey(i => i.DayID);

            HasMany(i => i.ScheduleLessons).WithRequired(i => i.Schedule);
        }
    }
}
