using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using My.Model;

namespace My.EntityFrameWork.EntityConfiguration
{
    public class BlogDetailsConfiguration : EntityTypeConfiguration<BlogDetails>
    {
        public BlogDetailsConfiguration()
        {
            Property(b => b.Description).HasMaxLength(250); 
        }
    }
}
