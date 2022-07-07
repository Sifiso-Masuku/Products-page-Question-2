using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Products_page_Question_2.Startup))]
namespace Products_page_Question_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
