using System.Collections.Generic;
using System.Linq;
using BlogData;
using BlogEntity;
using BlogInterface;

namespace BlogRepository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private BlogDBContext context = new BlogDBContext();
        public List<Comment> GetCommentsByPost(int id)
        {
            return context.Comments.Where(c => c.PostId == id).ToList(); 
        }
    }
}
