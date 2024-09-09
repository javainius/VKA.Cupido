using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SendGrid;
using VKA.Cupido.Clients;
using VKA.Cupido.Functions.Mappings;
using VKA.Cupido.Persistence;
using VKA.Cupido.Persistence.Interfaces;
using VKA.Cupido.Persistence.Repositories;
using VKA.Cupido.Services;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureAppConfiguration((context, config) =>
    {
        config.AddJsonFile("host.json", optional: true, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        string connectionString = context.Configuration.GetConnectionString("AzureSqlConnectionString");
        Console.WriteLine("Connection string: " + connectionString);

        services.AddDbContext<CupidoContext>(options =>
        options.UseSqlServer(
            connectionString,
            sqlOptions =>
            {
                sqlOptions.CommandTimeout(60);
                sqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(60), null);
            }
            )
        );
        //.UseSqlServer(context.Configuration.GetConnectionString("DbConnectionStrings")));

        services.AddAutoMapper(typeof(MappingProfile));
        IConfigurationSection sendGridSection = context.Configuration.GetSection("SendGrid");
        string apiKey = sendGridSection.GetValue<string>("ApiKey");
        Console.WriteLine("Api Key: " + apiKey);

        services.AddSingleton<ISendGridClient>(new SendGridClient(apiKey));
        services.AddTransient<IPersonRepository, PersonRepository>();
        services.AddTransient<IPairRepository, PairRepository>();
        services.AddTransient<IMailClient, MailClient>();
        services.AddTransient<IPairService, PairService>();
    })
    .Build();

host.Run();