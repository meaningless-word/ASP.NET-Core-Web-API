namespace ScreenApi.Contracts.Models
{
	public class Device
	{
		public long Capacity { get; set; }
		public string Manufacturer { get; set; }
		public StorageType StorageType { get; set; }
	}
}
