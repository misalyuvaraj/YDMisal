namespace YDMisal.API.Models.DTO
{
    // DTO used when a client sends data to CREATE a new walk difficulty
    public class AddWalkDifficultyRequest
    {
        // Code name for the difficulty (e.g., "Easy", "Hard") — required
        public string Code { get; set; } = string.Empty;
    }
}
