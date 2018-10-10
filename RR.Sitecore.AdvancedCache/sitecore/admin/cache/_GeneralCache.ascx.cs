using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore;

namespace RR.Sitecore.AdvancedCache.sitecore.admin.cache
{
	public partial class _GeneralCache : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnRefresh_OnClick(object sender, EventArgs e)
		{
			var caches = CacheManagerSingleton.Current.GetAllCaches().ToList();
			ListCaches(caches);
			DisplayTotalSizeInfo(caches);
		}

		private void DisplayTotalSizeInfo(IReadOnlyCollection<CacheInfo> caches)
		{
			labelTotals.Text =
				$"Entries: {caches.Sum(x => x.Count)}, Size: {MainUtil.FormatSize(caches.Sum(x => x.Size))}";
			labelCacheTitle.Text = $"Caches ({caches.Count})";
		}

		private void ListCaches(IReadOnlyCollection<CacheInfo> caches)
		{
			rptCaches.DataSource = caches.OrderBy(x => x.Name);
			rptCaches.DataBind();
		}

		protected void lbItemCacheFilter_OnClick(object sender, EventArgs e)
		{
			var cacheInfo = CacheManagerSingleton.Current.GetAllItemCaches("master");
			lblCacheInfo.Text = $"Name:{cacheInfo.Name} DatabaseName:{cacheInfo.DatabaseName} Count:{cacheInfo.Count} Size:{MainUtil.FormatSize(cacheInfo.CacheSize)}";
			rptItems.DataSource = cacheInfo.Items;
			rptItems.DataBind();
		}
	}
}