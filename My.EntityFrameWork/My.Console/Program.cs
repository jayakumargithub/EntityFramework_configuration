using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using My.EntityFrameWork;
using My.Model;

namespace My.Consolee
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //Derived model example
            using (var context = new MyContext())
            {
               // get all employee including manager using discriminiator column
                var employee = from e in context.Employees.OfType<Employee>()
                               where e.FullName.StartsWith("M")
                               select e;
                //get only manager excluding just employees
                var manager = from e in context.Employees.OfType<Manager>()
                              where e.FullName.StartsWith("M")
                              select e;

                foreach (var e in manager.ToList())
                {
                    Console.WriteLine(e.FullName);
                }



            }
            */

            using (var context = new MyContext())
            {

                var blog = context.Blogs.First(x => x.Id == 1);

                blog.BlogDetails.Description = "New description";
                blog.BlogDetails.DateCreated = DateTime.Now;
                //var blog = new Blog();
                //blog.BloggerName = "JK Blog1 ";
                //blog.Id = 1;
                //blog.Title = "First title1 ";
                //blog.BlogDetails = new BlogDetails()
                //{
                //    DateCreated = DateTime.Now,
                //    Description = "Blog details description1 "

                //};

                //context.Blogs.Add(blog);
                context.SaveChanges();
            }
                System.Console.ReadLine();
        }
    }
}
