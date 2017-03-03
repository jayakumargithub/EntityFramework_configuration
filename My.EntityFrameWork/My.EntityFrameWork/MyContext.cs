using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using My.EntityFrameWork.EntityConfiguration;
using My.Model;

namespace My.EntityFrameWork
{
   public  class MyContext : DbContext
    {
        public MyContext():base("name=MyContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Blog> Blogs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            

            //Configuration
            modelBuilder.Configurations.Add(new EmployeeConfiguration());

            modelBuilder.Configurations.Add(new UserConfiguration());
           // modelBuilder.Configurations.Add(new BlogDetailsConfiguration());

            //Convention
            modelBuilder.Conventions.Add(new PluralizingTableNameConvention());

          //  modelBuilder.ComplexType<BlogDetails>();

            //Note: if employee and manager table should create then following configure required.
            //if this configure is not exist then single table created with Discriminiation column
            modelBuilder.Types().Configure(c => c.ToTable(c.ClrType.Name));

            //if there is no ID property exists then follwoing config set the Key column as Primary Key

            //if you add .HasColumnOrder(1) and then different column add .HasColumnOrder(2)
            // then composite key for a table
          
            modelBuilder.Properties()
                        .Where(p => p.Name == "Key")
                        .Configure(p => p.IsKey().HasColumnOrder(1));

            modelBuilder.Properties()
                        .Where(p => p.Name == "Name")
                        .Configure(p => p.IsKey().HasColumnOrder(2));

           

           


            base.OnModelCreating(modelBuilder);
        }
    }
}
