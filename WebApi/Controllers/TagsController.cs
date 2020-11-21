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
    public class TagsController : ControllerBase
    {
        private readonly ITagRepository _repository;

        public TagsController(ITagRepository repository)
        {
            _repository = repository;
        }

        //Tags
        [HttpGet]
        public async Task<IEnumerable<Tag>> Get(CancellationToken cancellationtoken)
        {
            return await _repository.Get(cancellationtoken);
        }

        //Tags/ByName?name=Tag1
        [HttpGet("ByName")]
        public async Task<Tag> GetByName(string name, CancellationToken cancellationtoken)
        {
            return await _repository.GetByName(name, cancellationtoken);
        }
    }
}
