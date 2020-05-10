using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Extensions.Logging;
using FitAR.Sockets;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FitAR.Web
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
      Caching.CachingManager.Init();
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddRazorPages().AddRazorRuntimeCompilation();
      services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });
      services.AddControllersWithViews().AddRazorRuntimeCompilation();
      services.AddMvc().AddRazorRuntimeCompilation();
      services.AddMvc()
        .AddMvcOptions(options =>
        {
          // remove the existing JSON formatter
          options.OutputFormatters.RemoveType(typeof(Utf8Json.AspNetCoreMvcFormatter.JsonOutputFormatter));
          options.InputFormatters.RemoveType(typeof(Utf8Json.AspNetCoreMvcFormatter.JsonInputFormatter));

          // add utf8json formatters to handle JSON
          var resolver = Utf8Json.Resolvers.CompositeResolver.Create(
              Utf8Json.Resolvers.EnumResolver.UnderlyingValue,
              Utf8Json.Resolvers.StandardResolver.AllowPrivateExcludeNullCamelCase
          );

          options.OutputFormatters.Add(new Utf8Json.AspNetCoreMvcFormatter.JsonOutputFormatter(resolver));
          options.InputFormatters.Add(new Utf8Json.AspNetCoreMvcFormatter.JsonInputFormatter(resolver));

        }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);


      // HttpContextAccessor
      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
      services.AddHttpContextAccessor();
      services.AddScoped<ARContext>();
      services.AddScoped<ARScope>();

      services.AddWebSocketManager();

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
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      app.UseWebSockets();

      var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
      var serviceProvider = serviceScopeFactory.CreateScope().ServiceProvider;

      app.MapWebSocketManager("/ws_dashboard", serviceProvider.GetService<DashboardSocketHandler>());
      app.MapWebSocketManager("/ws_droid", serviceProvider.GetService<AndroidSocketManager>());

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
        endpoints.MapBlazorHub();
        endpoints.MapFallbackToPage("/_Host");
      });
    }
  }
}
