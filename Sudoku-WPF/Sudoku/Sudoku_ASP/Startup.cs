using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sudoku_ASP.Startup))]
namespace Sudoku_ASP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
