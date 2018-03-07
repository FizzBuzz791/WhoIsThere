using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace WhoIsThere
{
    public class Startup
    {
	    private const string TITLE = "Who Is There?";
		private const string VERSION = "v1";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

			// Register Swagger generator and define Swagger doc(s)
	        services.AddSwaggerGen(s => { s.SwaggerDoc(VERSION, new Info {Title = TITLE, Version = VERSION}); });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
			// Enable middleware to serve generated Swagger as a JSON endpoint.
	        app.UseSwagger();

			// Enable middleware to serve swagger-ui.
	        app.UseSwaggerUI(s => { s.SwaggerEndpoint($"/swagger/{VERSION}/swagger.json", TITLE); });

	        app.UseDefaultFiles();
	        app.UseStaticFiles();

            app.UseMvc();
        }
    }
}