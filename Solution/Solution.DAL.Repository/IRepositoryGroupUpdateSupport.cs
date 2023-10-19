using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.DAL.Repository
{
    public interface IRepositoryGroupUpdateSupport : IRepository<data.GroupUpdateSupport>
    {
        Task<IEnumerable<data.GroupUpdateSupport>> GetAllWithAsAsync();

        Task<data.GroupUpdateSupport> GetOneWithAsAsync(int id);

    }
}
