using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewGameAzure.API.DTO;
using ReviewGameAzure.API.DTO.Mappers;
using ReviewGameAzure.DAL.Interfaces;

namespace ReviewGameAzure.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _CategoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _CategoryRepository = categoryRepository;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<CategoryDTO> categories = _CategoryRepository.GetAll().Select(c => c.ToModelDTO());

            return Ok(categories);
        }
    }
}
