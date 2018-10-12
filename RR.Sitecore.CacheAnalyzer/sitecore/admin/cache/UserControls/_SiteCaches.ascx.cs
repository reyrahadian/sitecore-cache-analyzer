using System;
using RR.Sitecore.AdvancedCache.Managers;
using Sitecore;
using Sitecore.Configuration;

namespace RR.Sitecore.AdvancedCache.sitecore.admin.cache.UserControls
{
	public partial class _SiteCaches : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			rptSites.DataSource = SiteManager.Instance.GetAllSites();
			rptSites.DataBind();

			var siteContext = Factory.GetSite("habitat");
			var filteredItemsCache = global::Sitecore.Caching.CacheManager.GetFilteredItemsCache(siteContext);
			var htmlCache = global::Sitecore.Caching.CacheManager.GetHtmlCache(siteContext);
			var registryCache = global::Sitecore.Caching.CacheManager.GetRegistryCache(siteContext);
			var viewStateCache = global::Sitecore.Caching.CacheManager.GetViewStateCache(siteContext);
			var xslCache = global::Sitecore.Caching.CacheManager.GetXslCache(siteContext);

			lblFilteredItemsCacheInfo.Text = $"Name: {filteredItemsCache.Name} Count:{filteredItemsCache.InnerCache.Count} Size:{MainUtil.FormatSize(filteredItemsCache.InnerCache.Size)} MaxSize:{MainUtil.FormatSize(filteredItemsCache.InnerCache.MaxSize)}";
			rptFilteredItemCaches.DataSource = filteredItemsCache.InnerCache.GetCacheKeys();
			rptFilteredItemCaches.DataBind();

			lblHtmlCache.Text = $"Name: {htmlCache.Name} Count:{htmlCache.InnerCache.Count} Size:{MainUtil.FormatSize(htmlCache.InnerCache.Size)} MaxSize:{MainUtil.FormatSize(htmlCache.InnerCache.MaxSize)}";
			rptHtmlCache.DataSource = htmlCache.InnerCache.GetCacheKeys();
			rptHtmlCache.DataBind();
		}
	}
}