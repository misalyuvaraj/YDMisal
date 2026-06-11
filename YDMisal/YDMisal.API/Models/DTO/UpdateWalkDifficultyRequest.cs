namespace YDMisal.API.Models.DTO
{
    // DTO used when a client sends data to UPDATE an existing walk difficulty
    public class UpdateWalkDifficultyRequest
    {
        // Updated code name for the difficulty — required
        public string Code { get; set; } = string.Empty;
    }
}
