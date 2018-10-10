using System.Collections.Generic;

namespace RR.Sitecore.AdvancedCache
{
	public interface ICacheProvider
	{
		IEnumerable<CacheInfo> GetAllCaches();
		ItemCacheInfo GetAllItemCaches(string databaseName);
	}
}