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
    public class GroupUpdate : ICRUD<data.GroupUpdate>
    {
        private Repository<data.GroupUpdate> _repo = null;

        public GroupUpdate(SolutionDbContext solutionDbContext)
        {
            _repo = new Repository<data.GroupUpdate>(solutionDbContext);
        }

        public void Delete(data.GroupUpdate t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.GroupUpdate> GetAll()
        {
            return _repo.GetAll();
        }

        public data.GroupUpdate GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.GroupUpdate t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.GroupUpdate t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
