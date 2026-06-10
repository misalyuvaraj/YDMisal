using AutoMapper;

namespace YDMisal.API.Profile
{
    public class WalksProfile : AutoMapper.Profile
    {
        public WalksProfile()
        {
            CreateMap<Models.Domain.Walk, Models.DTO.Walk>();
            CreateMap<Models.Domain.WalkDifficulty, Models.DTO.WalkDifficulty>();
            CreateMap<Models.Domain.Region, Models.DTO.Region>();
        }
    }
}
