using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Options;
using Invenire.Configurations;

namespace Invenire;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        {
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.Configure<ApiConfiguration>(builder.Configuration.GetSection("ApiConfiguration"));
            builder.Services.AddScoped(services =>
            {
                var configuration = services.GetRequiredService<IOptions<ApiConfiguration>>().Value;
                return new HttpClient { BaseAddress = new Uri(configuration.BaseAddress) };
            });
        }

        await builder.Build().RunAsync();
    }
}
