using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.DAL.Repository
{
    public interface IRepositoryGroupComment : IRepository<data.GroupComment>
    {
        Task<IEnumerable<data.GroupComment>> GetAllWithAsAsync();

        Task<data.GroupComment> GetOneWithAsAsync(int id);
    }
}
