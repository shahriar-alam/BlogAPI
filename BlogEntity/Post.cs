using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEntity
{
    public class Post : Entity
    {
        public int UserId { set; get; }
        public int TopicId { set; get; }
        public string PostDetail { set; get; }
    }
}
