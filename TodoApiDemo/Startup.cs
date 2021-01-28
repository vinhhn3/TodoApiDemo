using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TodoApiDemo.Startup))]
namespace TodoApiDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
