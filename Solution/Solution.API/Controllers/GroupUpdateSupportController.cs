using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using datamodels = Solution.API.DataModels;
using data = Solution.DO.Objects;
using Solution.DAL.EF;
using AutoMapper;

namespace Solution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupUpdateSupportsController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public GroupUpdateSupportsController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/GroupUpdateSupports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.GroupUpdateSupport>>> GetGroupUpdateSupports()
        {
            var aux = await new BS.GroupUpdateSupport(_context).GetAllWithAsync();
            var mapaux = _mapper.Map<IEnumerable<data.GroupUpdateSupport>, IEnumerable<datamodels.GroupUpdateSupport>>(aux)
                .ToList();
            return mapaux;
        }

        // GET: api/GroupUpdateSupports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.GroupUpdateSupport>> GetGroupUpdateSupport(int id)
        {
           
            var groupUpdateSupport = await new BS.GroupUpdateSupport(_context).GetOneByIdWithAsync(id);
            var mapaux = _mapper.Map<data.GroupUpdateSupport, datamodels.GroupUpdateSupport>(groupUpdateSupport);

            if (mapaux == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/GroupUpdateSupports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupUpdateSupport(int id, datamodels.GroupUpdateSupport groupUpdateSupport)
        {
            if (id != groupUpdateSupport.GroupUpdateSupportId)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.GroupUpdateSupport,data.GroupUpdateSupport> (groupUpdateSupport);
                if(mapaux != null)
                {
                    new BS.GroupUpdateSupport(_context).Update(mapaux);
                }
                
            
            }
            catch (Exception ee)
            {
                if (!GroupUpdateSupportExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/GroupUpdateSupports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<datamodels.GroupUpdateSupport>> PostGroupUpdateSupport(datamodels.GroupUpdateSupport groupUpdateSupport)
        {
            var mapaux = _mapper.Map<datamodels.GroupUpdateSupport, data.GroupUpdateSupport>(groupUpdateSupport);
            new BS.GroupUpdateSupport (_context).Insert(mapaux);


            return CreatedAtAction("GetGroupUpdateSupport", new { id = groupUpdateSupport.GroupUpdateSupportId }, groupUpdateSupport);
        }

        // DELETE: api/GroupUpdateSupports/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.GroupUpdateSupport>> DeleteGroupUpdateSupport(int id)
        {

            var groupUpdateSupport = new BS.GroupUpdateSupport(_context).GetOneById(id);
            if (groupUpdateSupport == null)
            {
                return NotFound();
            }

            new BS.GroupUpdateSupport(_context).Delete(groupUpdateSupport);
            var mapaux = _mapper.Map<data.GroupUpdateSupport,datamodels.GroupUpdateSupport>(groupUpdateSupport);    

            

            return mapaux;
        }

        private bool GroupUpdateSupportExists(int id)
        {
            return (new BS.GroupUpdateSupport(_context).GetOneById(id) != null);
        }
    }
}
