using RR.Sitecore.AdvancedCache.Managers;
using Sitecore.Configuration;
using System;
using System.Linq;

namespace RR.Sitecore.AdvancedCache.sitecore.admin.cache.UserControls
{
	public partial class _DatabaseCache : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			var databases = Factory.GetDatabases();
			rptTableOfContent.DataSource = databases.Select(x => x.Name);
			rptTableOfContent.DataBind();

			rptDatabaseCachesInfo.DataSource = databases.Select(x => CacheManager.Instance.GetDatabaseCache(x.Name));
			rptDatabaseCachesInfo.DataBind();
		}		
	}
}