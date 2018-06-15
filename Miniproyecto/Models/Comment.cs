using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliApp.Models
{
    public class Comment
    {
        public int postId  {get; set; }
        public int id {get; set; }
        public String name {get; set; }
        public String email {get; set; }
        public String body {get; set; }
    }
}
