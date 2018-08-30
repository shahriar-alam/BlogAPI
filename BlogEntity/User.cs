using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogEntity
{
    public class User : Entity
    {
        public User()
        {
            UserId = Id;
        }
        public int UserId { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
    }
}
