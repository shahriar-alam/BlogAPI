using System.Collections.Generic;

namespace BlogEntity
{
    public class User : Entity
    {
        public string Name { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public List<Post> Posts { set; get; }
    }
}
