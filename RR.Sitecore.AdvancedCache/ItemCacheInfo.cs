using System.Collections.Generic;
using Sitecore.Data.Items;

namespace RR.Sitecore.AdvancedCache
{
	public class ItemCacheInfo
	{
		public ItemCacheInfo()
		{
			Items = new List<Item>();
		}

		public string Name { get; set; }
		public string DatabaseName { get; set; }
		public long CacheSize { get; set; }
		public ICollection<Item> Items { get; set; }
		public int Count { get; set; }
	}
}