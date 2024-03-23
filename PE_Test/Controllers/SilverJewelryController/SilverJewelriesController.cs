using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Query;

namespace PE_Test.Controllers.SilverJewelryController
{
    [Route("api/silverjewelries")]
    [ApiController]
    public class SilverJewelriesController : ControllerBase
    {
        private readonly ISilverJewelryRepository _silverJewelryRepo;

        public SilverJewelriesController(ISilverJewelryRepository silverJewelryRepo)
        {
            _silverJewelryRepo = silverJewelryRepo;
        }

        // GET: api/SilverJewelries
        [Authorize(Roles = "Admin, Staff")]
        [EnableQuery]
        [HttpGet]
        public ActionResult<IEnumerable<SilverJewelry>> GetSilverJewelries()
        {
            try
            {
                return Ok(_silverJewelryRepo.GetSilverJewelries().AsQueryable());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin, Staff")]
        [HttpGet]
        [Route("byname")]
        public ActionResult<IEnumerable<SilverJewelry>> GetSilverJewelriesByName(string name)
        {
            try
            {
                return Ok(_silverJewelryRepo.GetSilverJewelriesByName(name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin, Staff")]
        [HttpGet]
        [Route("byweight")]
        public ActionResult<IEnumerable<SilverJewelry>> GetSilverJewelriesByWeight(int weight)
        {
            try
            {
                return Ok(_silverJewelryRepo.GetSilverJewelriesByWeight(weight));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/SilverJewelries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult<SilverJewelry> AddSilverJewelry(SilverJewelry silverJewelry)
        {
            try
            {
                var result = _silverJewelryRepo.AddSilverJewelry(silverJewelry);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
