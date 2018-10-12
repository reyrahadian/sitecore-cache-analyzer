using System;

namespace RR.Sitecore.AdvancedCache.Models
{
	public class CacheCountByTemplateId
	{
		public Guid TemplateId { get; set; }
		public string TemplateName { get; set; }
		public int Count { get; set; }		
	}
}