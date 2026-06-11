namespace YDMisal.API.Profile
{
    // Tells AutoMapper how to convert a Region domain model to a Region DTO
    public class RegionsProfile : AutoMapper.Profile
    {
        public RegionsProfile()
        {
            // Map Domain Region → DTO Region (same property names, so no extra config needed)
            CreateMap<Models.Domain.Region, Models.DTO.Region>();
        }
    }
}
