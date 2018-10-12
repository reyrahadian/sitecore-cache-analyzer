using System.Collections.Generic;
using System.Linq;
using Sitecore.Configuration;

namespace RR.Sitecore.AdvancedCache.Managers
{
	public class SiteManager
	{
		private static readonly object padlock = new object();
		private static SiteManager _instance;
		public static SiteManager Instance
		{
			get
			{
				lock (padlock)
				{
					if (_instance == null)
					{
						lock (padlock)
						{
							_instance = new SiteManager();
						}
					}
				}

				return _instance;
			}
		}

		public IEnumerable<string> GetAllSites()
		{
			return Factory.GetSiteInfoList().Select(x => x.Name);
		}
	}
}