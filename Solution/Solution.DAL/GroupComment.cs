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
    public class GroupComment : ICRUD<data.GroupComment>
    {
        private RepositoryGroupComment _repo = null;

        public GroupComment(SolutionDbContext solutionDbContext)
        {
            _repo = new RepositoryGroupComment(solutionDbContext);
        }


        public void Delete(data.GroupComment t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.GroupComment> GetAll()
        {
            return _repo.GetAll();
        }

        public data.GroupComment GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.GroupComment t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.GroupComment t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public async Task<IEnumerable<data.GroupComment>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }
        public async Task<data.GroupComment> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetOneWithAsAsync(id);
        }
    }
}
