using BlogEntity;
using System.Collections.Generic;

namespace BlogInterface
{
    public interface ICommentRepository : IRepository<Comment>
    {
        List<Comment> GetCommentsByPost(int id);
    }
}
