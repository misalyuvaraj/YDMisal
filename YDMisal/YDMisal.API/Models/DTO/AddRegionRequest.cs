namespace YDMisal.API.Models.DTO
{
    // DTO used when a client sends data to CREATE a new region
    public class AddRegionRequest
    {
        // Region short code (required)
        public string Code { get; set; } = string.Empty;

        // Region full name (required)
        public string Name { get; set; } = string.Empty;

        // Area in square kilometers
        public double Area { get; set; }

        // Latitude
        public double Lat { get; set; }

        // Longitude
        public double Long { get; set; }

        // Population count
        public long Population { get; set; }
    }
}
