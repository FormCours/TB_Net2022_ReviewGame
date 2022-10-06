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


        /// <summary>
        /// Get all categories
        /// </summary>
        [HttpGet()]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CategoryDTO>))]
        public IActionResult GetAll()
        {
            IEnumerable<CategoryDTO> categories = _CategoryRepository.GetAll().Select(c => c.ToModelDTO());

            return Ok(categories);
        }

        /// <summary>
        /// Get category by unique identifier
        /// </summary>
        /// <param name="id">Category identifier</param>
        [HttpGet]
        [Route("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById([FromRoute]long id)
        {
            CategoryDTO? category = _CategoryRepository.GetById(id)?.ToModelDTO();

            if(category is null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        /// <summary>
        /// Get categories via a pattern contained in its name
        /// </summary>
        /// <param name="name">Pattern</param>
        [HttpGet]
        [Route("search")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CategoryDTO>))]
        public IActionResult GetByName([FromQuery] string name)
        {
            IEnumerable<CategoryDTO> categories = _CategoryRepository.GetByName(name).Select(c => c.ToModelDTO());

            return Ok(categories);
        }

        /// <summary>
        /// Insert a new category
        /// </summary>
        /// <param name="data">A new category</param>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CategoryDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Insert([FromBody] CategoryDataDTO data)
        {
            CategoryDTO result = _CategoryRepository.Insert(data.ToEntity()).ToModelDTO();

            return CreatedAtAction(nameof(GetById), new { Id = result.Id }, result);
        }

        /// <summary>
        /// Update a existing category
        /// </summary>
        /// <param name="id">Category identifier</param>
        /// <param name="data" >Data for update</param>
        [HttpPut]
        [Route("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update([FromRoute]long id, [FromBody] CategoryDataDTO data)
        {
            bool categoryNotFound = _CategoryRepository.GetById(id) is null;
            if(categoryNotFound)
            {
                return NotFound();
            }

            CategoryDTO result = _CategoryRepository.Update(id, data.ToEntity()).ToModelDTO();
            return Ok(result);
        }

        /// <summary>
        /// Delete a category by unique identifier
        /// </summary>
        /// <param name="id">Category identifier</param>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete([FromRoute] long id)
        {
            _CategoryRepository.Remove(id);
            return NoContent();
        }

    }
}
