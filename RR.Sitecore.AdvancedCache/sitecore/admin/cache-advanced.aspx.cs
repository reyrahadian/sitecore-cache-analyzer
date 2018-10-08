using Sitecore.sitecore.admin;
using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore;
using Sitecore.Web.UI.HtmlControls;

namespace RR.Sitecore.AdvancedCache.sitecore.admin
{
	public partial class AdvancedCacheAdmin : AdminPage
	{
		protected void Page_Init(object sender, EventArgs e)
		{
			RestrictAccessOnlyForAdminAndDeveloper();
		}

		private void RestrictAccessOnlyForAdminAndDeveloper()
		{
			CheckSecurity(true);
		}

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
	}
}