using Microsoft.EntityFrameworkCore;
using LoanApprovalService.DBContext;
using LoanApprovalService.Repository;
namespace LoanApprovalService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<LoanApprovalDBContext>(item =>
                item.UseSqlServer(Configuration.GetConnectionString("LoanApprovalDB")));
           // services.AddScoped<DbContext, UserContext>();
            services.AddTransient<ILoanApprovalRepository, LoanApprovalRepository>();
        }
        // Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseBrowserLink();
            }
            //app.UseCookiePolicy();
           // app.UseStaticFiles();
            //app.UseSession();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
