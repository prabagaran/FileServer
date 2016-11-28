using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FileServer.Startup))]
namespace FileServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
