using FluentAssertions;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace RR.Sitecore.AdvancedCache.Test
{
	public class CacheManagerTest
	{
		public class GetAllCaches
		{
			[Fact]
			public void Should_Return_Result()
			{
				var cacheProvider = new Mock<ICacheProvider>();
				cacheProvider.Setup(x => x.GetAllCaches()).Returns(new List<CacheInfo> {new CacheInfo()});
				var cacheManager = new CacheManager(cacheProvider.Object);

				cacheManager.GetAllCaches().Should().NotBeNullOrEmpty();
			}

			[Fact]
			public void Should_Return_Result_If_Provider_ReturnsNull()
			{
				var cacheProvider = new Mock<ICacheProvider>();
				cacheProvider.Setup(x => x.GetAllCaches()).Returns((IEnumerable<CacheInfo>)null);

				var cacheManager = new CacheManager(cacheProvider.Object);
				cacheManager.GetAllCaches().Should().NotBeNull();
			}
		}		
	}
}
