namespace YDMisal.API.Models.Domain
{
    // WalkDifficulty model — stores the difficulty level of a walk (e.g., Easy, Medium, Hard)
    public class WalkDifficulty
    {
        // Unique ID for each difficulty level
        public Guid Id { get; set; }

        // Code name for the difficulty level (e.g., "Easy", "Hard")
        public string Code { get; set; }
    }
}
