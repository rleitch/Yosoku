namespace Yosoku.AlphaVantage.DelegatingHandlers;

internal sealed class ApiKeyHandler(string apiKey) : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var uri = request.RequestUri!;
        var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
        query["apikey"] = apiKey;
        var builder = new UriBuilder(uri) { Query = query.ToString() };
        request.RequestUri = builder.Uri;

        return base.SendAsync(request, cancellationToken);
    }
}