using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrimeEduApp2.Startup))]
namespace PrimeEduApp2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
