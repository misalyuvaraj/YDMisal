namespace YDMisal.API.Models.DTO
{
    // DTO used when a client sends data to UPDATE an existing region
    public class UpdateRegionRequest
    {
        // Updated region short code (required)
        public string Code { get; set; } = string.Empty;

        // Updated region full name (required)
        public string Name { get; set; } = string.Empty;

        // Updated area in square kilometers
        public double Area { get; set; }

        // Updated latitude
        public double Lat { get; set; }

        // Updated longitude
        public double Long { get; set; }

        // Updated population count
        public long Population { get; set; }
    }
}
