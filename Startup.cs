using Microsoft.EntityFrameworkCore;
using UserService.DBContext;
using UserService.Repository;
namespace UserService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            //var builder = new ConfigurationBuilder()

            //   .AddJsonFile("appSettings.json");

            //Configuration = builder.Build();

        }

        public IConfiguration Configuration { get; }

        // Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<UserContext>(item =>
                item.UseSqlServer(Configuration.GetConnectionString("UserDB")));
           // services.AddScoped<DbContext, UserContext>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
        // Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        
              using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
	      {
        	    var context = serviceScope.ServiceProvider.GetRequiredService<UserContext>();
        	    context.Database.Migrate();
      	      }

            if (env.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();
                //app.UseBrowserLink();
            }
                app.UseDeveloperExceptionPage();
            //app.UseCookiePolicy();
            // app.UseStaticFiles();
            //app.UseSession();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();// Route(name: "default",
           // pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            app.Run( (context) => {

                throw new System.Exception("Throw Exception");

            });
        }
    }
}
