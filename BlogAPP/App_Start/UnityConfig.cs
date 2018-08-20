using System.Web.Http;
using BlogInterface;
using BlogRepository;
using Unity;

namespace BlogAPP.App_Start
{
    public class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<ITopicRepository, TopicRepository>();
            container.RegisterType<ICommentRepository, CommentRepository>();
            container.RegisterType<IPostRepository, PostRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(container);
        }
    }
}