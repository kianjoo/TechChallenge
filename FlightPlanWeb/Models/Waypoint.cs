namespace FlightplanWeb.Models
{
	public class Waypoint
	{
		public int seqNum { get; set; }
		public string designatedPoint { get; set; } = string.Empty;
		public string airway { get; set; } = string.Empty;
		public string speedCode { get; set; } = string.Empty;
		public string levelCode { get; set; } = string.Empty;
		public double latitude { get; set; }
		public double longitude { get; set; }
	}
}
