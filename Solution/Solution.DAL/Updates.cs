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
    public class Updates: ICRUD<data.Updates>
    {
        private Repository<data.Updates> _repo = null;

        public Updates(SolutionDbContext solutionDbContext)
        {
            _repo = new Repository<data.Updates>(solutionDbContext);
        }

        public void Delete(data.Updates t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Updates> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Updates GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }
        public data.Updates GetOneByMsg(string msg)
        {
            return _repo.GetOneByMsg(u => u.Updatemsg == msg);
        }

        public void Insert(data.Updates t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Updates t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
