using Microsoft.AspNetCore.Mvc;
using WebApplicationAPI.Models.Domain;
using WebApplicationAPI.Repositories;

namespace WebApplicationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
   // [Route("Regions")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;

        public RegionsController(IRegionRepository regionRepository)
        {
            this.regionRepository = regionRepository;
        }
        [HttpGet]
       public async Task<IActionResult> GetAllRegions()
        {
           var regions = await regionRepository.GetAllAsyn();//Direct sservice object getting call
           var regionsDto = new List<Models.DTO.Region>();
            regions.ToList().ForEach(region =>
            {
                var dtoRegion = new Models.DTO.Region()
                {
                    Id = region.Id,
                    Name = region.Name,
                    Code = region.Code,
                    Area = region.Area,
                    Late = region.Late,
                    Long = region.Long,
                    Population = region.Population

                };
                regionsDto.Add(dtoRegion);
            });
            return Ok(regionsDto);

        }
    }
}
