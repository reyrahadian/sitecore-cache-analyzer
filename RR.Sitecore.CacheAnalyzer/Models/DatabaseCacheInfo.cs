using System.Collections.Generic;

namespace RR.Sitecore.AdvancedCache.Models
{
	public class DatabaseCacheInfo
	{
		public string DatabaseName { get; set; }

		/// <summary>
		/// Data cache stores all data from all the data providers defined for the database.
		/// Each entry in the data cache represents a single item in the database, including parent/child relationships and field values for all version in all languages of that item.
		/// </summary>
		public DataCacheInfo DataCacheInfo { get; set; }

		/// <summary>
		/// Item cache stores information about a single version of an item in a single language.
		/// </summary>
		public ItemCacheInfo ItemCacheInfo { get; set; }

		/// <summary>
		/// Paths cache caches map URL path to item.
		/// </summary>
		public CacheInfo PathsCacheInfo { get; set; }

		/// <summary>
		/// Item paths cache supplements the existing Paths Cache.
		/// Item paths caches map item IDs and ItemPathTypes — Name, Key, DisplayName, or ItemID — to item paths, instead of generating these item paths over and over again.
		/// </summary>
		public ItemPathsCacheInfo ItemPathsCacheInfo { get; set; }

		/// <summary>
		/// Database standard values caches contain standard values for data templates in the database.
		/// </summary>
		public CacheInfo StandardValuesCacheInfo { get; set; }
	}
	
	public class DataCacheInfo : CacheInfo
	{
		public DataCacheInfo()
		{
			CacheCountsByTemplateIds = new List<CacheCountByTemplateId>();
		}

		public IEnumerable<CacheCountByTemplateId> CacheCountsByTemplateIds { get; set; }
	}
	
	public class ItemCacheInfo : CacheInfo
	{
		public ItemCacheInfo()
		{
			Items = new List<ItemInfo>();
			CacheCountsByTemplateIds = new List<CacheCountByTemplateId>();
		}

		public IEnumerable<ItemInfo> Items { get; set; }
		public IEnumerable<CacheCountByTemplateId> CacheCountsByTemplateIds { get; set; }
	}

	public class ItemPathsCacheInfo : CacheInfo
	{
		public IEnumerable<string> CacheInfoDetails { get; set; }
	}
}