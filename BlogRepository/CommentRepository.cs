using BlogEntity;
using BlogInterface;

namespace BlogRepository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
    }
}
