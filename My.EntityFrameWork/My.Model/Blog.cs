using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Model
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string BloggerName { get; set; }
        public BlogDetails BlogDetails { get; set; }
       // public virtual ICollection<Post> Posts { get; set; }
    }

   // public class Post
    //{
    //    public int Id { get; set; }
    //    public string Title { get; set; }
    //    public DateTime DateCreated { get; set; }
    //    public string Content { get; set; }
    //    public int BlogId { get; set; }

       
    //   // public ICollection<Comment> Comments { get; set; }
    //}

    [ComplexType]
    public class BlogDetails
    {
        public DateTime? DateCreated { get; set; }

        public string Description { get; set; }
    }
}
