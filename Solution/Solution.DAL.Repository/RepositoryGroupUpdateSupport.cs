using Microsoft.EntityFrameworkCore;
using Solution.DAL.EF;
using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.DAL.Repository
{
    public class RepositoryGroupUpdateSupport : Repository<data.GroupUpdateSupport>, IRepositoryGroupUpdateSupport
    {
        public RepositoryGroupUpdateSupport(SolutionDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<GroupUpdateSupport>> GetAllWithAsAsync()
        {
            return await _db.GroupUpdateSupports
                .Include(m => m.GroupUpdate)
                .ToListAsync();
        }

        public async Task<GroupUpdateSupport> GetOneWithAsAsync(int id)
        {
            return await _db.GroupUpdateSupports
                .Include(m => m.GroupUpdate)
                .SingleOrDefaultAsync(m=>m.GroupUpdateSupportId == id);
        }

        private SolutionDbContext _db
        {
            get { return dbContext as SolutionDbContext; }
        }
    }
}
