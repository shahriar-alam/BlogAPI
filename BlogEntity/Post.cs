using System;

namespace BlogEntity
{
    public class Post : Entity
    {
        public int UserId { set; get; }
        public int TopicId { set; get; }
        public DateTime DateTime { set; get; }
        public string PostDetail { set; get; }
    }
}
