using Solution.DAL.EF;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.BS
{
    public class GroupComment : ICRUD<data.GroupComment>
    {

        private SolutionDbContext _repo = null;

        public GroupComment(SolutionDbContext solutionDbContext)
        {
            _repo = solutionDbContext;
        }

        public void Delete(data.GroupComment t)
        {
            new DAL.GroupComment(_repo).Delete(t);
        }

        public IEnumerable<data.GroupComment> GetAll()
        {
            return new DAL.GroupComment(_repo).GetAll();
        }

        public data.GroupComment GetOneById(int id)
        {
            return new DAL.GroupComment(_repo).GetOneById(id);
        }

        public void Insert(data.GroupComment t)
        {
            new DAL.GroupComment(_repo).Insert(t);
        }

        public void Update(data.GroupComment t)
        {
            new DAL.GroupComment(_repo).Update(t);
        }
        public async Task<IEnumerable<data.GroupComment>> GetAllWithAsync()
        {
            return await new DAL.GroupComment(_repo).GetAllWithAsync();
        }
        public async Task<data.GroupComment> GetOneByIdWithAsync(int id)
        {
            return await new DAL.GroupComment(_repo).GetOneByIdWithAsync(id);
        }
    }
}
