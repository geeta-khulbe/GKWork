using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "reader")] //for authorization and authentication
        //[Authorize] // for authorization
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
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var region = await regionRepository.GetAsyn(id);
            Models.DTO.Region regionDto = new Models.DTO.Region();
            if (region != null)
            {
                regionDto.Id = region.Id;
                regionDto.Name = region.Name;
                regionDto.Code = region.Code;
                regionDto.Area = region.Area;
                regionDto.Late = region.Late;
                regionDto.Long = region.Long;
                regionDto.Population = region.Population;
                return Ok(regionDto);

            }
            else
            {
                return NotFound();
            }

        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddRegion(Models.DTO.AddRegionRequest addRegion)
        {
            var region = new Models.Domain.Region()
            {
                Name = addRegion.Name,
                Code = addRegion.Code,
                Area = addRegion.Area,
                Late = addRegion.Late,
                Long = addRegion.Long,
                Population = addRegion.Population,
            };
            region = await regionRepository.AddAsyn(region);
            var regionDto = new Models.DTO.Region()
            {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                Area = region.Area,
                Late = region.Late,
                Long = region.Long,
                Population = region.Population,
            };

            return CreatedAtAction(nameof(GetById), new { id = region.Id }, regionDto);
        }

        [HttpDelete]
        [Authorize]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegion(Guid id)
        {
            var data = await regionRepository.DeleteAsync(id);            
                return Ok(data);
            return Ok(data);

        }
        [HttpPut]
        [Authorize]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute]Guid id,[FromBody]Models.DTO.AddRegionRequest updateRegion)
        {
            var region = new Models.Domain.Region();
            region.Name = updateRegion.Name;
            region.Code = updateRegion.Code;
            var data = await regionRepository.UpdateAsync(id, region);
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
    }
}
