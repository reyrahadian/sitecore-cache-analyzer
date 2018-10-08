namespace RR.Sitecore.AdvancedCache
{
	public static class CacheManagerSingleton
	{
		private static CacheManager _cacheManager;
		private static object padLock = new object();
		public static CacheManager Current
		{
			get
			{
				lock (padLock)
				{
					if (_cacheManager == null)
					{
						lock (padLock)
						{
							_cacheManager = new CacheManager(new CacheProvider());
						}
					}
				}

				return _cacheManager;
			}
		}


		internal static void SetInstance(CacheManager cacheManager)
		{
			_cacheManager = cacheManager;
		}
	}
}