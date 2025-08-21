using Microsoft.AspNetCore.Components.WebAssembly.Http;

namespace Invenire.Common.Handlers;

public class CookieHandler : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
    {
        if (request.Headers.Authorization is null)
            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        return base.SendAsync(request, ct);
    }
}
