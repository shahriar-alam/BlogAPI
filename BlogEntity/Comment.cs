using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BlogEntity
{
    public class Comment : Entity
    {
        public Comment()
        {
            CommentId = Id;
        }
        public int CommentId { set; get; }
        [ForeignKey("User")]
        public int UserId { set; get; }
        public virtual User User { get; set; }
        //[ForeignKey("Post")][Required]
        public int PostId { get; set; }
        //public virtual Post Post { get; set; }
        //public virtual DateTime DateTime { set; get; }
        public string CommentDetail { set; get; }
    }
}
