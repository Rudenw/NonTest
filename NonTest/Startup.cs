using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NonTest.Startup))]
namespace NonTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
