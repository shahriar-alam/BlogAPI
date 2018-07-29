using BlogEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogInterface
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByEmail(string email);
        List<Post> GetPostByUserId(int id);
        List<Post> GetAllPost();
    }
}
