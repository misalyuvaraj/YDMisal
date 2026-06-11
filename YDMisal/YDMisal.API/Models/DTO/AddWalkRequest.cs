namespace YDMisal.API.Models.DTO
{
    // DTO used when a client sends data to CREATE a new walk
    public class AddWalkRequest
    {
        // Name of the walk (required)
        public string Name { get; set; } = string.Empty;

        // Length of the walk in km
        public double Lenght { get; set; }

        // ID of the region this walk belongs to
        public Guid RegionId { get; set; }

        // ID of the difficulty level for this walk
        public Guid WalkDifficultyId { get; set; }
    }
}
