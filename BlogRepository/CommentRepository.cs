using BlogEntity;
using BlogInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogRepository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
    }
}
