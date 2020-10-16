using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FPTTraining0.Startup))]
namespace FPTTraining0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
