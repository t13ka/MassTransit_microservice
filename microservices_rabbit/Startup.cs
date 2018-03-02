namespace Web
{
    using System;
    using System.IO;

    using Abstractions.Messages.Command;
    using Abstractions.Messages.Command.Responses;

    using Autofac;
    using Autofac.Extensions.DependencyInjection;

    using Environment;
    using Environment.ConnectionProviders.Rabbit;

    using MassTransit;
    using MassTransit.Util;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.SpaServices.Webpack;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    public class Startup
    {
        private IContainer _container;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var configurationRoot = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionProvider = new LocalConnectionProvider(configurationRoot);
            var bus = Bus.Factory.CreateUsingRabbitMq(
                sbc => sbc.Host(
                    new Uri(connectionProvider.UriString),
                    h =>
                        {
                            h.Username(connectionProvider.Username);
                            h.Password(connectionProvider.Password);
                        }));

            var builder = new ContainerBuilder();
            builder.Register(c => bus).As<IBusControl>().As<IPublishEndpoint>().SingleInstance();

            // clients for external microservices
            builder
                .Register(
                    c => new MessageRequestClient<IGetSomeDataCommand, IGetSomeDataCommandResponse>(
                        bus,
                        connectionProvider.GetEndpoint(KnownServicesTypes.GetSomeDataCommandHandler),
                        TimeSpan.FromSeconds(10)))
                .As<IRequestClient<IGetSomeDataCommand, IGetSomeDataCommandResponse>>()
                .SingleInstance();

            builder.Populate(services);
            _container = builder.Build();

            return new AutofacServiceProvider(_container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            IApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions { HotModuleReplacement = true });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(
                routes =>
                    {
                        routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");

                        routes.MapSpaFallbackRoute(
                            name: "spa-fallback",
                            defaults: new { controller = "Home", action = "Index" });
                    });

            // resolve the bus from the container
            var bus = _container.Resolve<IBusControl>();

            // start the bus
            var busHandle = TaskUtil.Await(() => bus.StartAsync());

            // register an action to call when the application is shutting down
            lifetime.ApplicationStopping.Register(() => busHandle.Stop());
        }
    }
}