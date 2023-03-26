using AutoMapper;
using Microsoft.Extensions.Caching.Memory;

namespace api.Domain.Configure
{
    public class CacheSegments
    {

        private readonly IMemoryCache _cache;
        private readonly IMapper _mapper;

        public CacheSegments(IMemoryCache cache, IMapper mapper)
        {
            _cache = cache;
            _mapper = mapper;

        }

    }
}
