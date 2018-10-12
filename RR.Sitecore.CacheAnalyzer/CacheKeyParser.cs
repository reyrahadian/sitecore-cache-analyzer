using System;

namespace RR.Sitecore.AdvancedCache
{
	public class CacheKeyParser
	{
		private readonly string _cacheKey;

		public CacheKeyParser(string cacheKey)
		{
			_cacheKey = cacheKey;
		}

		private const int GuidCharLength = 38;
		public Guid GetItemId()
		{
			return new Guid(_cacheKey.Substring(0, GuidCharLength));
		}

		private const string VersionSeparator = "¤";
		public string GetLanguageCode()
		{			
			var itemIdStringRemoved = _cacheKey.Remove(0, GuidCharLength);
			var versionSeparatorIndex = itemIdStringRemoved.IndexOf(VersionSeparator);

			return itemIdStringRemoved.Substring(0, versionSeparatorIndex);
		}

		public int GetVersion()
		{
			var startIndex = _cacheKey.IndexOf(VersionSeparator)+1;

			return int.Parse(_cacheKey.Substring(startIndex));
		}
	}
}