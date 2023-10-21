using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solution.DAL.EF;
using data = Solution.DO.Objects;
using datamodels = Solution.API.DataModels;

namespace Solution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdatesController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public UpdatesController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Updates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.Updates>>> GetUpdates()
        {
            var aux = new BS.Updates(_context).GetAll();
            var mapaux = _mapper.Map<IEnumerable<data.Updates>,IEnumerable<datamodels.Updates>>(aux).ToList();
            return mapaux;
        }

        // GET: api/Updates/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<datamodels.Updates>> GetUpdate(int id)
        {
           
            var update = new BS.Updates(_context).GetOneById(id);
            if (update == null)
            {
                return NotFound();
            }
            var mapaux = _mapper.Map<data.Updates,datamodels.Updates>(update);

           

            return mapaux;
        }

        /*------------------------------------*/
        // GET: api/Updates/5
        [HttpGet("bymsg/{msg}")]
        public async Task<ActionResult<datamodels.Updates>> GetUpdateByMsg(string msg)
        {

            var update = new BS.Updates(_context).GetOneByMsg(msg);
            if (update == null)
            {
                return NotFound();
            }
            var mapaux = _mapper.Map<data.Updates, datamodels.Updates>(update);



            return mapaux;
        }

        /*------------------------------------*/


        // PUT: api/Updates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUpdate(int id, datamodels.Updates update)
        {
            if (id != update.UpdateId)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.Updates, data.Updates>(update);

                new BS.Updates(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!UpdateExists(id))
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

        // POST: api/Updates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<datamodels.Updates>> PostUpdate(datamodels.Updates update)
        {

            var mapaux = _mapper.Map<datamodels.Updates, data.Updates>(update);
            new BS.Updates (_context).Insert(mapaux);

            return CreatedAtAction("GetUpdate", new { id = update.UpdateId }, update);
        }

        // DELETE: api/Updates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.Updates>> DeleteUpdate(int id)
        {
            
            var update = new BS.Updates(_context).GetOneById(id);   

            if (update == null)
            {
                return NotFound();
            }
            new BS.Updates (_context).Delete(update);
            var mapaux = _mapper.Map<data.Updates,datamodels.Updates>(update);

            return mapaux;
        }

        private bool UpdateExists(int id)
        {
            return (new BS.Updates(_context).GetOneById(id)!=null);
        }
    }
}
