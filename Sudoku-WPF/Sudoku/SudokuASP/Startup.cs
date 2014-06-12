using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SudokuASP.Startup))]
namespace SudokuASP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
