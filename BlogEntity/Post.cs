using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogEntity
{
    public class Post : Entity
    {
        public Post()
        {
            PostId = Id;
        }
        public int PostId { get; set; }
        [ForeignKey("User")]
        public int UserId { set; get; }
        public virtual User User { get; set; }
        [ForeignKey("Topic")]
        public int TopicId { set; get; }
        public virtual Topic Topic { get; set; }
        //[ForeignKey("Comments")]
        //public int? CommentId { set; get; }
        //public virtual ICollection<Comment> Comments { set; get; }
        public DateTime DateTime { set; get; }
        public string title { get; set; }
        public string PostDetail { set; get; }
    }
}
