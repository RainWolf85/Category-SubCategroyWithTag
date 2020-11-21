using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _repository;
        private readonly ITagRepository _tagRepository;

        public CategoriesController(ICategoryRepository repository, ITagRepository tagRepository)
        {
            _repository = repository;
            _tagRepository = tagRepository;
        }

        //Categories/ByName?name=A
        [HttpGet("ByName")]
        public async Task<Category> GetByName(string name, CancellationToken cancellationtoken)
        {
            return await _repository.GetByName(name, cancellationtoken);
        }

        //Categories/ByPartOfName?partOfName=A
        [HttpGet("ByPartOfName")]
        public async Task<IEnumerable<Category>> GetByPartOfName(string partOfName, CancellationToken cancellationtoken)
        {
            return await _repository.GetByPartOfName(partOfName, cancellationtoken);
        }

        //Categories/GetSubCategoriesByTagName?tagName=Tag1
        [HttpGet("GetSubCategoriesByTagName")]
        public async Task<IEnumerable<Category>> GetSubCategoriesByTagName(string tagName, CancellationToken cancellationtoken)
        {
            return await _tagRepository.GetSubCategoriesByName(tagName, cancellationtoken);
        }
    }
}