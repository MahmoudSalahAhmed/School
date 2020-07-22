using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("User");
            Property(i => i.Name).HasMaxLength(40).IsRequired();
            Property(i => i.Email).HasMaxLength(40).IsRequired();
            Property(i => i.Phone).HasMaxLength(20).IsRequired();

            HasOptional(i => i.Admin)
                .WithRequired(i => i.User);

            HasOptional(i => i.Teacher)
                .WithRequired(i => i.User);

            HasOptional(i => i.Student)
              .WithRequired(i => i.User);

        }
    }
}
