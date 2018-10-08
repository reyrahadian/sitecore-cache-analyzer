using System.Collections.Generic;
using System.Linq;

namespace RR.Sitecore.AdvancedCache
{
	public class CacheProvider : ICacheProvider
	{
		public IEnumerable<CacheInfo> GetAllCaches()
		{
			var caches = global::Sitecore.Caching.CacheManager.GetAllCaches();
			if (caches != null)
			{
				return caches.Select(x => new CacheInfo
				{
					Name = x.Name,
					Count = x.Count,
					Size = x.Size,
					MaxSize = x.MaxSize
				});

			}

			return new List<CacheInfo>();
		}
	}
}