using System;
using System.Web.UI.WebControls;
using Sitecore.sitecore.admin;

namespace RR.Sitecore.AdvancedCache.sitecore.admin.cache
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

		protected void ChangeTab(object sender, EventArgs e)
		{
			var linkButton = (LinkButton) sender;
			cacheTabs.ActiveViewIndex = int.Parse(linkButton.CommandArgument);
		}
	}
}