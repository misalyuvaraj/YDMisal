namespace YDMisal.API.Profile
{
    // Tells AutoMapper how to convert Walk and WalkDifficulty domain models to their DTOs
    public class WalksProfile : AutoMapper.Profile
    {
        public WalksProfile()
        {
            // Map Domain Walk → DTO Walk
            CreateMap<Models.Domain.Walk, Models.DTO.Walk>();

            // Map Domain WalkDifficulty → DTO WalkDifficulty
            CreateMap<Models.Domain.WalkDifficulty, Models.DTO.WalkDifficulty>();
        }
    }
}
