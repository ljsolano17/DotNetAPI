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
    public class GroupUpdate : ICRUD<data.GroupUpdate>
    {
        private SolutionDbContext context;

        public GroupUpdate(SolutionDbContext _context)
        {
            context = _context;
        }

        public void Delete(data.GroupUpdate t)
        {
            new DAL.GroupUpdate(context).Delete(t);
        }

        public IEnumerable<data.GroupUpdate> GetAll()
        {
            return new DAL.GroupUpdate(context).GetAll();
        }

        public data.GroupUpdate GetOneById(int id)
        {
            return new DAL.GroupUpdate(context).GetOneById(id);
        }

        public void Insert(data.GroupUpdate t)
        {
            new DAL.GroupUpdate(context).Insert(t);
        }

        public void Update(data.GroupUpdate t)
        {
            new DAL.GroupUpdate(context).Update(t);
        }
    }
}
