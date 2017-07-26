using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameOfThrones.Startup))]
namespace GameOfThrones
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
