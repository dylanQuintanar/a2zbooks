using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(A2ZBooks.Startup))]
namespace A2ZBooks
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
