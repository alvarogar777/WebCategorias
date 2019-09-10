using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebCategorias.Startup))]
namespace WebCategorias
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
