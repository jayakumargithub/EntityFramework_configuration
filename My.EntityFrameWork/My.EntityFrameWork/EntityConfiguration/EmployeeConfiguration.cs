using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My.Model;

namespace My.EntityFrameWork
{ 
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            //FullName column won't be added to the table
            //this.Ignore(e => e.FullName);
            //Property(e => e.FullName).IsRequired();
        }
    }
}
