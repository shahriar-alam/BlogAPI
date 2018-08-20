using BlogEntity;
using BlogInterface;

namespace BlogRepository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
    }
}
