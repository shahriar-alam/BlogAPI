using BlogData;
using BlogEntity;
using BlogInterface;
using System.Collections.Generic;
using System.Linq;

namespace BlogRepository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private BlogDBContext context = new BlogDBContext();

        public List<Post> GetAllPost()
        {
            return this.context.Posts.ToList();
        }

        public List<Post> GetPostByUserId(int id)
        {
            return this.context.Posts.Where(p => p.User.Id == id).ToList();
        }

        public User GetUserByEmail(string email)
        {
            return this.context.Users.SingleOrDefault(p => p.Email == email);
        }
    }
}
