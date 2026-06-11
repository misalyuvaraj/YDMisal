namespace YDMisal.API.Models.DTO
{
    // DTO (Data Transfer Object) used to send region data back to the client
    public class Region
    {
        // Unique ID of the region
        public Guid Id { get; set; }

        // Short code (e.g., "AKL")
        public string Code { get; set; }

        // Full name of the region
        public string Name { get; set; }

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
