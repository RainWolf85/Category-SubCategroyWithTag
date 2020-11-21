using Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetByName(string name, CancellationToken cancellationtoken);

        Task<IEnumerable<Category>> GetByPartOfName(string name, CancellationToken cancellationtoken);
    }
}