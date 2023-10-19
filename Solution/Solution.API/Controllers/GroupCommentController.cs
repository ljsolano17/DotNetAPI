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
    public class GroupCommentsController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public GroupCommentsController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/GroupComments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.GroupComment>>> GetGroupComments()
        {
            var aux = await new Solution.BS.GroupComment(_context).GetAllWithAsync();
            var mapaux = _mapper.Map<IEnumerable<data.GroupComment>, IEnumerable<datamodels.GroupComment>>(aux).ToList();

            return mapaux;
        }

        // GET: api/GroupComments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.GroupComment>> GetGroupComment(int id)
        {
            var groupComment = await new Solution.BS.GroupComment(_context).GetOneByIdWithAsync(id);
            var mapaux = _mapper.Map<data.GroupComment, datamodels.GroupComment>(groupComment);

            if (mapaux == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/GroupComments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupComment(int id, datamodels.GroupComment groupComment)
        {

            if (id != groupComment.GroupCommentId)
            {
                return BadRequest();
            }

            try
            {

                var mapaux = _mapper.Map<datamodels.GroupComment, data.GroupComment>(groupComment);

                // var existingGroup = new Solution.BS.Focus(_context).GetOneByIdWithAsync(id);
                
                new Solution.BS.GroupComment(_context).Update(mapaux);
                

                /* var mapaux = _mapper.Map<datamodels.GroupComment, data.GroupComment>(groupComment);

                 var existingGroupComment = await new Solution.BS.GroupComment(_context).GetOneByIdWithAsync(id);

                 if (existingGroupComment != null)
                 {

                     _context.Entry(existingGroupComment).State = EntityState.Detached;
                     _context.Entry(mapaux).State = EntityState.Modified;




                     await _context.SaveChangesAsync();*/
            
            }
            catch (Exception ee)
            {
                if (!GroupCommentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
            /* if (id != groupComment.GroupCommentId)
             {
                 return BadRequest();
             }

             try
             {
                 var mapaux = _mapper.Map<datamodels.GroupComment, data.GroupComment>(groupComment);

                 new BS.GroupComment(_context).Update(mapaux);
             }
             catch (Exception ee)
             {
                 if (!GroupCommentExists(id))
                 {
                     return NotFound();
                 }
                 else
                 {
                     throw;
                 }
             }

             return NoContent();*/
        }

        // POST: api/GroupComments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<datamodels.GroupComment>> PostGroupComment(datamodels.GroupComment groupComment)
        {
            
           var mapaux = _mapper.Map<datamodels.GroupComment, data.GroupComment>(groupComment);
           new Solution.BS.GroupComment(_context).Insert(mapaux);

            return CreatedAtAction("GetGroupComment", new { id = groupComment.GroupCommentId }, groupComment);
        }

        // DELETE: api/GroupComments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.GroupComment>> DeleteGroupComment(int id)
        {
           
            var groupComment =  new Solution.BS.GroupComment(_context).GetOneById(id);
            if (groupComment == null)
            {
                return NotFound();
            }
            new Solution.BS.GroupComment(_context).Delete(groupComment);
            var mapaux = _mapper.Map<data.GroupComment, datamodels.GroupComment>(groupComment);


            return mapaux;
        }

        private bool GroupCommentExists(int id)
        {
            return (new Solution.BS.GroupComment(_context).GetOneById(id) != null);
        }
    }
}
