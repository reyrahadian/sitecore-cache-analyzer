namespace RR.Sitecore.AdvancedCache
{
	public class CacheInfo
	{
		public string Name { get; set; }
		public int Count { get; set; }
		public long Size { get; set; }
		public uint DeltaSize { get; set; }
		public long MaxSize { get; set; }
	}
}