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
    public class RepositoryGroupComment : Repository<data.GroupComment>, IRepositoryGroupComment
    {
        public RepositoryGroupComment(SolutionDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<GroupComment>> GetAllWithAsAsync()
        {
            return await _db.GroupComments
                .Include(m=>m.GroupUpdate)
                .ToListAsync();
        }

        public async Task<GroupComment> GetOneWithAsAsync(int id)
        {
            return await _db.GroupComments
                .Include(m => m.GroupUpdate)
                .SingleOrDefaultAsync(m => m.GroupCommentId == id);
        }

        private SolutionDbContext _db
        {
            get { return dbContext as SolutionDbContext; }
        }
    }
}
