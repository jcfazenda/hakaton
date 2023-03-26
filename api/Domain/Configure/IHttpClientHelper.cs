namespace Api.Domain.Configure
{
    public interface IHttpClientHelper
    {
        string GetAsync(string url);
    }
}
