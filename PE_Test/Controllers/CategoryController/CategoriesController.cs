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

namespace PE_Test.Controllers.CategoryController
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepsitory _categoryRepository;

        public CategoriesController(ICategoryRepsitory categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }



        // GET: api/Categories

        [HttpGet]
        [Authorize(Roles = "Admin, Staff")]

        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            try
            {
                return Ok(_categoryRepository.GetCategories());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
