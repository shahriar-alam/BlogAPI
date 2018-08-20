using System.Collections.Generic;

namespace BlogEntity
{
    public class Topic : Entity
    {
        public string TopicName { set; get; }
        public List<Post> Posts { get; set; }
    }
}
