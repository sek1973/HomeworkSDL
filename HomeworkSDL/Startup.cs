using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomeworkSDL.Startup))]
namespace HomeworkSDL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
