using BlogEntity;
using System.Collections.Generic;

namespace BlogInterface
{
    public interface IUserRepository : IRepository<User>
    {
        
        User GetUserByEmail(string email);
        List<Post> GetPostByUserId(int id);
        List<Post> GetAllPost();
        
    }
}
