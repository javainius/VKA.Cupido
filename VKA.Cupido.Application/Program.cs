using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SendGrid;
using VKA.Cupido.Application;
using VKA.Cupido.Application.Mappings;
using VKA.Cupido.Clients;
using VKA.Cupido.Persistence;
using VKA.Cupido.Persistence.Interfaces;
using VKA.Cupido.Persistence.Repositories;
using VKA.Cupido.Services;

var host = CreateHostBuilder(args).Build();

// Run the application
Application application = host.Services.GetRequiredService<Application>();
await application.Run();

static IHostBuilder CreateHostBuilder(string[] args) =>
     Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((hostingContext, config) =>
        {
            // Ensure the appsettings.json file is loaded
            config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            config.AddEnvironmentVariables();

            if (args != null)
            {
                config.AddCommandLine(args);
            }
        })
        .ConfigureServices((context, services) =>
        {
            services.AddSingleton<Application>(); // Register the main application class
            services.AddDbContext<CupidoContext>(options => options
                .UseSqlServer(context.Configuration.GetConnectionString("DbConnectionStrings")));

            services.AddAutoMapper(typeof(MappingProfile));
            IConfigurationSection sendGridSection = context.Configuration.GetSection("SendGrid");
            string apiKey = sendGridSection.GetValue<string>("ApiKey");
            services.AddSingleton<ISendGridClient>(new SendGridClient(apiKey));
            services.AddSingleton<IPersonRepository, PersonRepository>();
            services.AddTransient<IPairRepository, PairRepository>();
            services.AddTransient<IMailClient, MailClient>();
            services.AddTransient<IPairService, PairService>();
        });

//--------------------------
//string? apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY", EnvironmentVariableTarget.User);
