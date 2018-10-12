using RR.Sitecore.AdvancedCache.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RR.Sitecore.AdvancedCache.sitecore.admin.cache.UserControls
{
	public partial class CacheCountsByTemplateIdTable : System.Web.UI.UserControl
	{
		public IEnumerable<CacheCountByTemplateId> CacheCountsByTemplateIds { get; set; }

		protected void Page_Load(object sender, EventArgs e)
		{
			rptCacheCounts.DataSource = CacheCountsByTemplateIds.OrderByDescending(x => x.Count);
			rptCacheCounts.DataBind();
		}
	}
}