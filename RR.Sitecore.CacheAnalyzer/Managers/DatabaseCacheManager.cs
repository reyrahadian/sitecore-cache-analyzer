using RR.Sitecore.AdvancedCache.Models;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.Globalization;
using System.Linq;

namespace RR.Sitecore.AdvancedCache.Managers
{
	public class DatabaseCacheManager
	{
		public DatabaseCacheInfo GetDatabaseCache(string databaseName)
		{
			var databaseCacheInfo = new DatabaseCacheInfo();
			var database = Factory.GetDatabase(databaseName);
			databaseCacheInfo.DatabaseName = database.Name;

			SetDataCacheInfo(databaseCacheInfo, database);
			SetItemCacheInfo(databaseCacheInfo, database);
			SetItemPathsCacheInfo(databaseCacheInfo, database);
			SetPathsCacheInfo(databaseCacheInfo, database);
			SetStandardValuesCacheInfo(databaseCacheInfo, database);

			return databaseCacheInfo;
		}

		private static void SetStandardValuesCacheInfo(DatabaseCacheInfo databaseCacheInfo, Database database)
		{
			databaseCacheInfo.StandardValuesCacheInfo = new CacheInfo
			{
				Name = database.Caches.StandardValuesCache.InnerCache.Name,
				Count = database.Caches.StandardValuesCache.InnerCache.Count,
				Size = database.Caches.StandardValuesCache.InnerCache.Size,
				MaxSize = database.Caches.StandardValuesCache.InnerCache.MaxSize
			};
		}

		private static void SetPathsCacheInfo(DatabaseCacheInfo databaseCacheInfo, Database database)
		{
			databaseCacheInfo.PathsCacheInfo = new CacheInfo
			{
				Name = database.Caches.PathCache.InnerCache.Name,
				Count = database.Caches.PathCache.InnerCache.Count,
				Size = database.Caches.PathCache.InnerCache.Size,
				MaxSize = database.Caches.PathCache.InnerCache.MaxSize
			};
		}

		private static void SetItemPathsCacheInfo(DatabaseCacheInfo databaseCacheInfo, Database database)
		{
			databaseCacheInfo.ItemPathsCacheInfo = new ItemPathsCacheInfo
			{
				Name = database.Caches.ItemPathsCache.InnerCache.Name,
				Count = database.Caches.ItemPathsCache.InnerCache.Count,
				Size = database.Caches.ItemPathsCache.InnerCache.Size,
				MaxSize = database.Caches.ItemPathsCache.InnerCache.MaxSize,
				CacheInfoDetails = database.Caches.ItemPathsCache.InnerCache.GetCacheKeys()
					.Select(x => database.Caches.ItemPathsCache.GetItemPath(x.ItemId, ItemPathType.Name))
			};
		}

		private static void SetItemCacheInfo(DatabaseCacheInfo databaseCacheInfo, Database database)
		{
			databaseCacheInfo.ItemCacheInfo = new ItemCacheInfo
			{
				Name = database.Caches.ItemCache.InnerCache.Name,
				Count = database.Caches.ItemCache.InnerCache.Count,
				Size = database.Caches.ItemCache.InnerCache.Size,
				MaxSize = database.Caches.ItemCache.InnerCache.MaxSize,
				Items = database.Caches.ItemCache.InnerCache.GetCacheKeys().Select(cacheKey =>
				{
					var cacheKeyParser = new CacheKeyParser(cacheKey);
					var item = database.Caches.ItemCache.GetItem(new ID(cacheKeyParser.GetItemId()),
						Language.Parse(cacheKeyParser.GetLanguageCode()), global::Sitecore.Data.Version.Parse(cacheKeyParser.GetVersion()));

					return new ItemInfo
					{
						Name = item.Name,
						Language = item.Language.Name,
						Path = item.Paths.FullPath,
						Version = item.Version.Number
					};
				}),
				CacheCountsByTemplateIds = database.Caches.ItemCache.InnerCache.GetCacheKeys()
					.Select(cacheKey =>
					{
						var cacheKeyParser = new CacheKeyParser(cacheKey);
						var item = database.Caches.ItemCache.GetItem(new ID(cacheKeyParser.GetItemId()),
							Language.Parse(cacheKeyParser.GetLanguageCode()), global::Sitecore.Data.Version.Parse(cacheKeyParser.GetVersion()));
						return item.TemplateID;
					})
					.GroupBy(x => x)
					.Where(x => x != null)
					.Select(x => new CacheCountByTemplateId
					{
						TemplateId = x.Key.Guid,
						TemplateName = TemplateManager.GetTemplate(x.Key, database).FullName,
						Count = x.Count()
					})
			};
		}

		private static void SetDataCacheInfo(DatabaseCacheInfo databaseCacheInfo, Database database)
		{
			databaseCacheInfo.DataCacheInfo = new DataCacheInfo
			{
				Name = database.Caches.DataCache.InnerCache.Name,
				Count = database.Caches.DataCache.InnerCache.Count,
				Size = database.Caches.DataCache.InnerCache.Size,
				MaxSize = database.Caches.DataCache.InnerCache.MaxSize,
				CacheCountsByTemplateIds = database.Caches.DataCache.InnerCache.GetCacheKeys()
					.Select(x => database.Caches.DataCache.GetItemInformation(x).ItemDefinition.TemplateID)
					.GroupBy(x => x)
					.Where(x => x != null)
					.Select(x => new CacheCountByTemplateId
					{
						TemplateId = x.Key.Guid,
						TemplateName = TemplateManager.GetTemplate(x.Key, database).FullName,
						Count = x.Count()
					})
			};
		}
	}
}