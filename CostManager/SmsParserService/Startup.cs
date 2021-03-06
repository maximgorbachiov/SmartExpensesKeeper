using CommonUtilities.Serializers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmsParserService.Proxy;
using SmsParserService.Services;

namespace SmsParserService
{
    public class Startup
    {
        public delegate ISmsHandler ServiceResolver(Bank bank);

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();
            services.AddTransient<IBlankPurchasesProxy, BlankPurchasesProxy>();
            services.AddTransient<ISerializer, JsonSerializer>();
            services.AddTransient<DefaultSmsHandler>();
            services.AddTransient<IdeaBankSmsHandler>();
            services.AddTransient<ServiceResolver>(serviceProvider => bankName =>
            {
                return bankName switch
                {
                    Bank.IdeaBank => serviceProvider.GetService<IdeaBankSmsHandler>(),
                    _ => serviceProvider.GetService<DefaultSmsHandler>()
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                GrpcEndpointRouteBuilderExtensions.MapGrpcService<SmsParser>(endpoints);

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}
