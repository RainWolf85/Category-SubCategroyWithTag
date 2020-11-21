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
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<Tag>> Get(CancellationToken cancellationtoken)
        {
            return await TableNoTracking
                .Include(row => row.Categories)
                .ToListAsync(cancellationtoken);
        }

        public async Task<Tag> GetByName(string name, CancellationToken cancellationtoken)
        {
            return await TableNoTracking
                .Include(row => row.Categories)
                .SingleOrDefaultAsync(row => row.Name.Equals(name), cancellationtoken);
        }
        
        public async Task<IEnumerable<Category>> GetSubCategoriesByCategoryId(int categoryId, CancellationToken cancellationtoken)
        {
            return await TableNoTracking
                .Include(row => row.Categories)
                .Where(row => row.Categories.FirstOrDefault().Id.Equals(categoryId))
                .SelectMany(row => row.Categories)
                .Where(row => row.IsSubCategory)
                .ToListAsync(cancellationtoken) ;
        }

        public async Task<IEnumerable<Category>> GetSubCategoriesByName(string name, CancellationToken cancellationtoken)
        {
            return await TableNoTracking
                .Include(row => row.Categories)
                .Where(row => row.Name.Equals(name))
                .SelectMany(row => row.Categories)
                .Where(row => row.IsSubCategory)
                .ToListAsync(cancellationtoken);
        }
    }
}
