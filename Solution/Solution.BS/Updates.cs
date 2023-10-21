using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

using Solution.DAL.EF;

namespace Solution.BS
{
    public class Updates : ICRUD<data.Updates>
    {
        private SolutionDbContext context;
        public Updates(SolutionDbContext _context)
        {
            context = _context;
        }

        public void Delete(data.Updates t)
        {
            new DAL.Updates(context).Delete(t);
        }

        public IEnumerable<data.Updates> GetAll()
        {
           return new DAL.Updates(context).GetAll();
        }

        public data.Updates GetOneById(int id)
        {
            return new DAL.Updates(context).GetOneById(id);
        }
        public data.Updates GetOneByMsg(string msg)
        {
            return new DAL.Updates(context).GetOneByMsg(msg);
            
        }

        public data.Updates GetOneByMsg(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Updates t)
        {
            new DAL.Updates(context).Insert(t);
        }

        public void Update(data.Updates t)
        {
            new DAL.Updates(context).Update(t);
        }
    }
}
