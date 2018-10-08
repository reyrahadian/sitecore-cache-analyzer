using System.Collections.Generic;

namespace RR.Sitecore.AdvancedCache
{
	public class CacheManager
	{
		private readonly ICacheProvider _cacheProvider;

		public CacheManager(ICacheProvider cacheProvider)
		{
			_cacheProvider = cacheProvider;
		}

		public IEnumerable<CacheInfo> GetAllCaches()
		{
			return _cacheProvider.GetAllCaches() ?? new List<CacheInfo>();
		}
	}
}