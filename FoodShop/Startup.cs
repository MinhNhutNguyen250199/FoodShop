using FluentValidation.AspNetCore;
using FoodShop.LocalizationResources;
using FoodShopModel.FluentValidator;
using FoodShopServiceAPI;
using LazZiya.ExpressLocalization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Globalization;

namespace FoodShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddHttpClient();

            var cultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("vi-VN"),
            };

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
             .AddCookie(options =>
             {
                 options.LoginPath = "/User/Login";
                 options.AccessDeniedPath = "/User/Forbidden/";
             });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ISlideAPI, SlideAPI>();
            services.AddScoped<IProductAPI, ProductAPI>();
            services.AddScoped<ICategoryAPI, CategoryAPI>();
            services.AddScoped<IUserAPI, UserAPI>();

            services.AddControllersWithViews()
               .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>())
               .AddExpressLocalization<ExpressLocalizationResource, ViewLocalizationResource>(ops =>
               {
                    // When using all the culture providers, the localization process will
                    // check all available culture providers in order to detect the request culture.
                    // If the request culture is found it will stop checking and do localization accordingly.
                    // If the request culture is not found it will check the next provider by order.
                    // If no culture is detected the default culture will be used.

                    // Checking order for request culture:
                    // 1) RouteSegmentCultureProvider
                    //      e.g. http://localhost:1234/tr
                    // 2) QueryStringCultureProvider
                    //      e.g. http://localhost:1234/?culture=tr
                    // 3) CookieCultureProvider
                    //      Determines the culture information for a request via the value of a cookie.
                    // 4) AcceptedLanguageHeaderRequestCultureProvider
                    //      Determines the culture information for a request via the value of the Accept-Language header.
                    //      See the browsers language settings

                    // Uncomment and set to true to use only route culture provider
                    ops.UseAllCultureProviders = false;
                   ops.ResourcesPath = "LocalizationResources";
                   ops.RequestLocalizationOptions = o =>
                   {
                       o.SupportedCultures = cultures;
                       o.SupportedUICultures = cultures;
                       o.DefaultRequestCulture = new RequestCulture("vi-VN");
                   };
               }); ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();

            app.UseRequestLocalization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Product Category En",
                    pattern: "{culture}/Category/{id}", new
                    {
                        controller = "Product",
                        action = "Category"
                    });

                endpoints.MapControllerRoute(
                  name: "Product Category Vn",
                  pattern: "{culture}/Danh-muc/{id}", new
                  {
                      controller = "Product",
                      action = "Category"
                  });

                endpoints.MapControllerRoute(
                    name: "Product Detail En",
                    pattern: "{culture}/products/{id}", new
                    {
                        controller = "Product",
                        action = "Detail"
                    });

                endpoints.MapControllerRoute(
                  name: "Product Detail Vn",
                  pattern: "{culture}/san-pham/{id}", new
                  {
                      controller = "Product",
                      action = "Detail"
                  });
                endpoints.MapControllerRoute(
                     name: "default",
                     pattern: "{culture=vi-VN}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "NewProduct Vn",
                    pattern: " {culture}/san-pham-moi", new
                    {
                        controller = "Product",
                        action = "NewProduct"
                    } );
                endpoints.MapControllerRoute(
                    name: "NewProduct En",
                    pattern: " {culture}/new-product", new
                    {
                        controller = "Product",
                        action = "NewProduct"
                    });

            });
        }
    }
}
