using System;

namespace BlogEntity
{
    public class Comment : Entity
    {
        public int PostId { set; get; }
        public int CommentorId { set; get; }
        public DateTime DateTime { set; get; }
        public string CommentDetail { set; get; }
    }
}
