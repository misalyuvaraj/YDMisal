namespace YDMisal.API.Models.DTO
{
    // DTO used to send walk data back to the client
    // Includes the nested Region and WalkDifficulty objects
    public class Walk
    {
        // Unique ID of the walk
        public Guid Id { get; set; }

        // Name of the walk
        public string Name { get; set; }

        // Length of the walk in km (typo kept intentionally — see domain model note)
        public double Lenght { get; set; }

        // ID of the region this walk is in
        public Guid RegionId { get; set; }

        // ID of the difficulty level
        public Guid WalkDifficultyId { get; set; }

        // Full region details (returned in response)
        public Region Region { get; set; }

        // Full difficulty level details (returned in response)
        public WalkDifficulty WalkDifficulty { get; set; }
    }
}
