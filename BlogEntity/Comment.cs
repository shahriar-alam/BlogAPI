﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEntity
{
    public class Comment : Entity
    {
        public int PostId { set; get; }
        public string CommentDetail { set; get; }
    }
}