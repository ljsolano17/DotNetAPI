using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
    public class GroupUpdateSupport : ICRUD<data.GroupUpdateSupport>
    {
        private RepositoryGroupUpdateSupport _repo = null;

        public GroupUpdateSupport (SolutionDbContext solutionDbContext)
        {
            _repo = new RepositoryGroupUpdateSupport(solutionDbContext);
        }

        public void Delete(data.GroupUpdateSupport t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.GroupUpdateSupport> GetAll()
        {
            return _repo.GetAll();
        }

        public data.GroupUpdateSupport GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.GroupUpdateSupport t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.GroupUpdateSupport t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public async Task<IEnumerable<data.GroupUpdateSupport>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }
        public async Task<data.GroupUpdateSupport> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetOneWithAsAsync(id);
        }
    }
}
