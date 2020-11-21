using Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<Category> GetByName(string name, CancellationToken cancellationtoken)
        {
            return await TableNoTracking
                .Include(row => row.Tag)
                .SingleOrDefaultAsync(row => row.Name.Equals(name), cancellationtoken);
        }

        public async Task<IEnumerable<Category>> GetByPartOfName(string name, CancellationToken cancellationtoken)
        {
            return await TableNoTracking
                .Include(row => row.Tag)
                .Where(row => row.Name.Contains(name))
                .ToListAsync(cancellationtoken);
        }
    }
}
