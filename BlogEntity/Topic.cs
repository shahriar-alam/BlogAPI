using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogEntity
{
    public class Topic : Entity
    {
        public Topic()
        {
            TopicId = Id;
        }
        public int TopicId { get; set; }
        public string TopicName { set; get; }

    }
}
