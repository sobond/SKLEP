using Hangfire;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sklep_MJ.Startup))]
namespace Sklep_MJ
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            GlobalConfiguration.Configuration.UseSqlServerStorage("CoursesContext");

            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}
