namespace YDMisal.API.Models.Domain
{
    // Region model — stores information about a geographic region in New Zealand
    public class Region
    {
        // Unique ID for each region
        public Guid Id { get; set; }

        // Short code for the region (e.g., "AKL" for Auckland)
        public string Code { get; set; }

        // Full name of the region
        public string Name { get; set; }

        // Area size of the region in square kilometers
        public double Area { get; set; }

        // Latitude coordinate of the region
        public double Lat { get; set; }

        // Longitude coordinate of the region
        public double Long { get; set; }

        // Total population of the region
        public long Population { get; set; }

        // List of walks available in this region (navigation property)
        public IEnumerable<Walk> Walks { get; set; }
    }
}
