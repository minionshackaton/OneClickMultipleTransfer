using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OneClickMultipleTransfer.Startup))]
namespace OneClickMultipleTransfer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
        }
    }
}
