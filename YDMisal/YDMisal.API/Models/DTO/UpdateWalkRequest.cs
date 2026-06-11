namespace YDMisal.API.Models.DTO
{
    // DTO used when a client sends data to UPDATE an existing walk
    public class UpdateWalkRequest
    {
        // Updated walk name (required)
        public string Name { get; set; } = string.Empty;

        // Updated length in km
        public double Lenght { get; set; }

        // Updated region ID
        public Guid RegionId { get; set; }

        // Updated difficulty level ID
        public Guid WalkDifficultyId { get; set; }
    }
}
