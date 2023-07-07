using Microsoft.Extensions.Options;
using WebApplication2.Configurations;

namespace WebApplication2.Services
{
    public class MetaService
    {
        private readonly Configuration _options;
        private readonly IHttpClientFactory _httpClientFactory;

        public MetaService(IOptions<Configuration> options, IHttpClientFactory httpClientFactory)
        {
            _options = options.Value;
            _httpClientFactory = httpClientFactory;
        }
    }
}
