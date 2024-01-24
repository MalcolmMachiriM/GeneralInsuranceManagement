using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GeneralInsuranceManagement.Startup))]
namespace GeneralInsuranceManagement
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
