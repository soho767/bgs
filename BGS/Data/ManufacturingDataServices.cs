using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace BGS.Data;

public static class ManufacturingDataServices
{
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
    private static Type _keepDateOnly = typeof(DateOnly);

    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
    private static Type _keepTimeOnly = typeof(TimeOnly);

    //public static void AddManufacturingDataClient(this IServiceCollection serviceCollection, Action<IServiceProvider, ManufacturingDataClientOptions> configure)
    //{
    //    serviceCollection.AddScoped(services =>
    //    {
    //        var options = new ManufacturingDataClientOptions();
    //        configure(services, options);
    //        var httpClient = new HttpClient(new GrpcWebHandler(GrpcWebMode.GrpcWeb, options.MessageHandler!));
    //        var channel = GrpcChannel.ForAddress(options.BaseUri!, new GrpcChannelOptions { HttpClient = httpClient, MaxReceiveMessageSize = null });
    //        return new BlazeOrbital.Data.ManufacturingData.ManufacturingDataClient(channel);
    //    });
    //}

    public static void AddManufacturingDataDbContext(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContextFactory<ClientSideDbContext>(
            options => options.UseSqlite($"Filename={DataSynchronizer.SqliteDbFilename}"));
        serviceCollection.AddScoped<DataSynchronizer>();
    }
}

public class ManufacturingDataClientOptions
{
    public string? BaseUri { get; set; }
    public HttpMessageHandler? MessageHandler { get; set; }
}
