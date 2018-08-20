using System;

namespace BlogEntity
{
    public class Comment : Entity
    {
        public DateTime DateTime { set; get; }
        public string CommentDetail { set; get; }
        public User User { set; get; }
        public Post Post { set; get; }
    }
}
