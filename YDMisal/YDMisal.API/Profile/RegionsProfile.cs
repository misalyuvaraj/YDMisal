namespace YDMisal.API.Profile
{
    public class RegionsProfile : AutoMapper.Profile
    {
        public RegionsProfile()
        {
            CreateMap<Models.Domain.Region, Models.DTO.Region>();
        }
    }
}
