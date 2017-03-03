using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My.Model;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace My.EntityFrameWork.EntityConfiguration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            this.HasMany(u => u.Roles)
                .WithMany()
                .Map(m =>
                {

                    m.MapLeftKey("Roles");
                    m.MapRightKey("User");
                    m.ToTable("UserRoles");
                }); 
        }
    }
}
