using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using datamodels = Solution.API.DataModels;
using data = Solution.DO.Objects;
using Solution.DAL.EF;
using AutoMapper;
using System.Collections.Generic;

namespace Solution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupUpdatesController : ControllerBase
    {
        private readonly SolutionDbContext _context;

        private readonly IMapper _mapper;

        public GroupUpdatesController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/GroupUpdates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.GroupUpdate>>> GetGroupUpdates()
        {
            var aux = new Solution.BS.GroupUpdate(_context).GetAll();

            var mapaux = _mapper.Map<IEnumerable<data.GroupUpdate>, IEnumerable<datamodels.GroupUpdate>>(aux).ToList();

            if (mapaux == null)
            {
                return NotFound();
            }
            return mapaux;
        }

        // GET: api/GroupUpdates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.GroupUpdate>> GetGroupUpdate(int id)
        {

            var groupUpdate = new Solution.BS.GroupUpdate(_context).GetOneById(id);

            if (groupUpdate == null)
            {
                return NotFound();
            }

            var mapaux = _mapper.Map<data.GroupUpdate,datamodels.GroupUpdate>(groupUpdate);
            if (mapaux == null)
            {
                return NoContent();
            }
            return mapaux;
        }

        // PUT: api/GroupUpdates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupUpdate(int id, datamodels.GroupUpdate groupUpdate)
        {
            if (id != groupUpdate.GroupUpdateId)
            {
                return BadRequest();
            }
                        
            try
            {
                var mapaux = _mapper.Map<datamodels.GroupUpdate,data.GroupUpdate>(groupUpdate);
                new Solution.BS.GroupUpdate(_context).Update(mapaux);
               // return Ok("Actualizado!");
            }
            catch (Exception ee)
            {
                if (!GroupUpdateExists(id))
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

        // POST: api/GroupUpdates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<datamodels.GroupUpdate>> PostGroupUpdate(datamodels.GroupUpdate groupUpdate)
        {

            var mapaux = _mapper.Map<datamodels.GroupUpdate, data.GroupUpdate>(groupUpdate);
            new Solution.BS.GroupUpdate(_context).Insert(mapaux);

            return CreatedAtAction("GetGroupUpdate", new { id = groupUpdate.GroupUpdateId }, groupUpdate);
        }

        // DELETE: api/GroupUpdates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.GroupUpdate>> DeleteGroupUpdate(int id)
        {

            var groupUpdate = new Solution.BS.GroupUpdate(_context).GetOneById(id);
            if (groupUpdate == null)
            {
                return NotFound();
            }

            new Solution.BS.GroupUpdate(_context).Delete(groupUpdate);
            var mapaux = _mapper.Map<data.GroupUpdate, datamodels.GroupUpdate>(groupUpdate);

            return mapaux;
        }

        private bool GroupUpdateExists(int id)
        {
            return (new Solution.BS.GroupUpdate(_context).GetOneById(id)!=null);
        }
    }
}
