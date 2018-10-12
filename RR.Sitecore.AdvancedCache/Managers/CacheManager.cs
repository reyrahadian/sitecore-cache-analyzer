using System.Collections.Generic;
using System.Linq;
using RR.Sitecore.AdvancedCache.Models;

namespace RR.Sitecore.AdvancedCache.Managers
{
	public class CacheManager
	{
		private static CacheManager _cacheManager;
		private static readonly object padLock = new object();
		private readonly DatabaseCacheManager _databaseCacheManager;

		public CacheManager()
		{
			_databaseCacheManager = new DatabaseCacheManager();
		}

		public static CacheManager Instance
		{
			get
			{
				lock (padLock)
				{
					if (_cacheManager == null)
						lock (padLock)
						{
							_cacheManager = new CacheManager();
						}
				}

				return _cacheManager;
			}
		}

		public IEnumerable<CacheInfo> GetAllCaches()
		{
			var caches = global::Sitecore.Caching.CacheManager.GetAllCaches();
			if (caches != null)
				return caches.Select(x => new CacheInfo
				{
					Name = x.Name,
					Count = x.Count,
					Size = x.Size,
					MaxSize = x.MaxSize
				});

			return new List<CacheInfo>();
		}

		public DatabaseCacheInfo GetDatabaseCache(string databaseName)
		{
			return _databaseCacheManager.GetDatabaseCache(databaseName);
		}
	}
}