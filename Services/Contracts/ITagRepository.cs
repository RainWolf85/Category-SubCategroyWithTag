using Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ITagRepository : IRepository<Tag>
    {
        Task<IEnumerable<Tag>> Get(CancellationToken cancellationtoken);
        Task<Tag> GetByName(string name, CancellationToken cancellationtoken);
        Task<IEnumerable<Category>> GetSubCategoriesByName(string name, CancellationToken cancellationtoken);
    }
}