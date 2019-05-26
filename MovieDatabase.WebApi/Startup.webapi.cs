using Microsoft.AspNetCore.Builder;

namespace MovieDatabase.WebApi
{
    public partial class Startup
    {
        public void ConfigureWebApi(IApplicationBuilder app)
        {
            app.UseMvcWithDefaultRoute();
            app.UseCors("AllowAllHeaders");

        }
        
    }
}