using System;
using Sitecore.sitecore.admin;

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
			var caches = CacheManagerSingleton.Current.GetAllCaches();
			rptCaches.DataSource = caches;
			rptCaches.DataBind();
		}
	}
}