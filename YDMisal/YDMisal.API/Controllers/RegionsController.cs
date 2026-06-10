using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YDMisal.API.Models.Domain;
using YDMisal.API.Repository;

namespace YDMisal.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
          var regions = regionRepository.GetAllAsync();
            // retun DTO  regions

            //var regionsDto = new List<Models.DTO.Region>();

            //regions.ToList().ForEach(region =>
            //{
            //    var regionDTO = new Models.DTO.Region()
            //    {
            //        Id = region.Id,
            //        Code = region.Code,
            //        Name = region.Name,
            //        Area = region.Area,
            //        Lat = region.Lat,
            //        Long = region.Long,
            //        Population = region.Population,
            //    };
            //});

           var regionsDTO = mapper.Map<Models.Domain.Region>(regions);

            return Ok(regionsDTO);
        }
    }

}