namespace YDMisal.API.Models.DTO
{
    // DTO used to send walk difficulty data back to the client
    public class WalkDifficulty
    {
        // Unique ID of the difficulty level
        public Guid Id { get; set; }

        // Code name (e.g., "Easy", "Medium", "Hard")
        public string Code { get; set; }
    }
}
