using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ruby.Startup))]
namespace Ruby
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
