using Invenire;
using Invenire.Common.Handlers;
using Invenire.Configurations;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Options;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.Configure<ApiConfiguration>(builder.Configuration.GetSection("ApiConfiguration"));
        builder.Services.AddTransient<CookieHandler>();

        builder.Services.AddScoped(sp =>
        {
            var configuration = sp.GetRequiredService<IOptions<ApiConfiguration>>().Value;

            return new HttpClient(new CookieHandler
            {
                InnerHandler = new HttpClientHandler()
            })
            {
                BaseAddress = new Uri(configuration.BaseAddress)
            };
        });

        await builder.Build().RunAsync();
    }
}
