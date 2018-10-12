using System;
using System.Collections.Generic;
using System.Linq;
using RR.Sitecore.AdvancedCache.Managers;
using RR.Sitecore.AdvancedCache.Models;
using Sitecore;

namespace RR.Sitecore.AdvancedCache.sitecore.admin.cache.UserControls
{
	public partial class _GeneralCache : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnRefresh_OnClick(object sender, EventArgs e)
		{
			var caches = CacheManager.Instance.GetAllCaches().ToList();
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
	}
}