namespace YDMisal.API.Models.Domain
{
    // Walk model — stores information about a single hiking walk
    public class Walk
    {
        // Unique ID for each walk
        public Guid Id { get; set; }

        // Name of the walk
        public string Name { get; set; }

        // Length of the walk in kilometers
        // Note: "Lenght" is a typo — should be "Length" in future refactoring
        public double Lenght { get; set; }

        // ID of the region this walk belongs to
        public Guid RegionId { get; set; }

        // ID of the difficulty level for this walk
        public Guid WalkDifficultyId { get; set; }

        // Related region object (navigation property)
        public Region Region { get; set; }

        // Related difficulty level object (navigation property)
        public WalkDifficulty WalkDifficulty { get; set; }
    }
}
