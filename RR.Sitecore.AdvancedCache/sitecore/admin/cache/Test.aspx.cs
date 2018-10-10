using System;
using System.Linq;
using Sitecore.Configuration;

namespace RR.Sitecore.AdvancedCache.sitecore.admin.cache
{
	public partial class cache_advanced_test : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			var databases = Factory.GetDatabases();
			lbl.Text = string.Join(" ",databases.Select(x => x.Name ));
		}
	}
}