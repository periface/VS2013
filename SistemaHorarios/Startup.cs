using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaHorarios.Startup))]
namespace SistemaHorarios
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
