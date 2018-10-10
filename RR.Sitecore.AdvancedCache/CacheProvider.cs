using System.Collections.Generic;
using System.Linq;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Globalization;

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

		public ItemCacheInfo GetAllItemCaches(string databaseName)
		{
			var itemCache = global::Sitecore.Caching.CacheManager.GetItemCache(Factory.GetDatabase(databaseName));
			var cacheKeys = itemCache.InnerCache.GetCacheKeys();			
			var cacheInfo = new ItemCacheInfo();
			cacheInfo.Name = itemCache.Name;
			cacheInfo.DatabaseName = databaseName;
			cacheInfo.CacheSize = itemCache.InnerCache.Size;
			cacheInfo.Count = itemCache.InnerCache.Count;
			
			foreach (var cacheKey in cacheKeys)
			{
				var cacheKeyParser = new CacheKeyParser(cacheKey);
				var item = itemCache.GetItem(new ID(cacheKeyParser.GetItemId()),
					Language.Parse(cacheKeyParser.GetLanguageCode()), Version.Parse(cacheKeyParser.GetVersion()));
				cacheInfo.Items.Add(item);
			}

			return cacheInfo;
		}
	}
}