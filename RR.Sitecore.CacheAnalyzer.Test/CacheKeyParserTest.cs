using System;
using FluentAssertions;
using Xunit;

namespace RR.Sitecore.AdvancedCache.Test
{
	public class CacheKeyParserTest
	{
		private const string CacheKey = "{0BD9682B-2725-48E4-AAF6-950ADDC3CA19}en¤0";

		[Fact]
		public void Should_Extract_Guid()
		{
			var parser = new CacheKeyParser(CacheKey);

			var itemId = parser.GetItemId();

			itemId.Should().Be(new Guid("{0BD9682B-2725-48E4-AAF6-950ADDC3CA19}"));
		}

		[Fact]
		public void Should_Extract_LanguageCode()
		{
			var parser = new CacheKeyParser(CacheKey);

			var languageCode = parser.GetLanguageCode();

			languageCode.Should().Be("en");
		}

		[Fact]
		public void Should_Extract_VersionNumber()
		{
			var parser = new CacheKeyParser(CacheKey);

			var version = parser.GetVersion();

			version.Should().Be(0);
		}
	}
}