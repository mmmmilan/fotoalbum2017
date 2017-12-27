using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFotoAlbum3.Startup))]
namespace WebFotoAlbum3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
