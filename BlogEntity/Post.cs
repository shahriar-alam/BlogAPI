using System;
using System.Collections.Generic;

namespace BlogEntity
{
    public class Post : Entity
    {
        public DateTime DateTime { set; get; }
        public string PostTitle { get; set; }
        public string PostDetail { set; get; }
        public User User { get; set; }
        public List<Comment> Comments { set; get; }
        public List<Topic> Topics { set; get; }
    }
}
