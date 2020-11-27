namespace GreenCap.Web
{
    using System.Reflection;

    using GreenCap.Data;
    using GreenCap.Data.Common;
    using GreenCap.Data.Common.Repositories;
    using GreenCap.Data.Models;
    using GreenCap.Data.Repositories;
    using GreenCap.Data.Seeding;
    using GreenCap.Services;
    using GreenCap.Services.Data;
    using GreenCap.Services.Data.Contracts;
    using GreenCap.Services.Mapping;
    using GreenCap.Services.Messaging;
    using GreenCap.Web.ViewModels;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment environment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            this.configuration = configuration;
            this.environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            if (this.environment.IsDevelopment())
            {
                services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptionsDevelopment)
                        .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();
            }
            else if (this.environment.IsProduction())
            {
                services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptionsProduction)
                        .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();
            }

            services.Configure<CookiePolicyOptions>(
                options =>
                    {
                        options.CheckConsentNeeded = context => true;
                        options.MinimumSameSitePolicy = SameSiteMode.None;
                    });

            services.AddControllersWithViews(
                options =>
                    {
                        options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                    }).AddRazorRuntimeCompilation();
            services.AddRazorPages(); // small services 40/50

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddSingleton(this.configuration);

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<IEmailSender, NullMessageSender>();
            services.AddTransient<ISettingsService, SettingsService>();
            services.AddTransient<IProposalService, ProposalService>();
            services.AddTransient<IPostservice, PostService>();
            services.AddTransient<IHomeService, HomeService>();
            services.AddTransient<IPhysNewsScarperService, PhysNewsScarperService>();
            services.AddTransient<INewsService, NewsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            // register middleware
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // middware
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                    {
                        endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapRazorPages();
                    });
        }
    }
}
