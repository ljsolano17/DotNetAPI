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
    public class GroupUpdateSupport : ICRUD<data.GroupUpdateSupport>
    {
        private  SolutionDbContext _repo = null;
        public GroupUpdateSupport(SolutionDbContext solutionDbContext)
        {
            _repo = solutionDbContext;
        }

        public void Delete(data.GroupUpdateSupport t)
        {
            new DAL.GroupUpdateSupport(_repo).Delete(t);
        }

        public IEnumerable<data.GroupUpdateSupport> GetAll()
        {
            return new DAL.GroupUpdateSupport(_repo).GetAll();
        }

        public data.GroupUpdateSupport GetOneById(int id)
        {
            return new DAL.GroupUpdateSupport(_repo).GetOneById(id);
        }

        public void Insert(data.GroupUpdateSupport t)
        {
            new DAL.GroupUpdateSupport(_repo).Insert(t);
        }

        public void Update(data.GroupUpdateSupport t)
        {
            new DAL.GroupUpdateSupport(_repo).Update(t);
        }

        public async Task<IEnumerable<data.GroupUpdateSupport>> GetAllWithAsync()
        {
            return await new DAL.GroupUpdateSupport(_repo).GetAllWithAsync();
        }

        public async Task<data.GroupUpdateSupport> GetOneByIdWithAsync(int id)
        {
            return await new DAL.GroupUpdateSupport(_repo).GetOneByIdWithAsync(id);
        }
    }
}
