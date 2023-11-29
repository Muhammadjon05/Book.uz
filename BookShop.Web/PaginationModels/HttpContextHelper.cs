namespace BookShop.Web.PaginationModels;

public class HttpContextHelper
{
    private readonly IHttpContextAccessor? _httpContext;

    public HttpContextHelper(IHttpContextAccessor? httpContext)
    {
        _httpContext = httpContext;
    }


    public void AddResponseToHeader(string key, string value)
    {
        if (_httpContext == null)
        {
            return;
        }

        if (_httpContext.HttpContext!.Response.Headers.ContainsKey(key))
        {
            _httpContext.HttpContext!.Response.Headers.Remove(key);
        }
        _httpContext.HttpContext!.Response.Headers.Add("Access-Control-Expose-Headers", key);
        _httpContext.HttpContext!.Response.Headers.Add(key, value);
    }
}