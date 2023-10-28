using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using data = FrontEnd.API.Models;

namespace FrontEnd.API.Controllers
{
    public class GroupCommentsController : Controller
    {

        string baseurl = "http://localhost:5084/";

        // GET: GroupComments
        public async Task<IActionResult> Index()
        {
            List<data.GroupComment> aux = new List<data.GroupComment>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/GroupComments");

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.GroupComment>>(auxres);
                }
            }
            return View(aux);

        }

        // GET: GroupComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupComment = GetById(id);


            if (groupComment == null)
            {
                return NotFound();
            }

         

            return View(groupComment);
        }

        // GET: GroupComments/Create
        public IActionResult Create()
        {
            ViewData["GroupUpdateId"] = new SelectList(getAllGroupUpdates(), "GroupUpdateId", "GroupUpdateId");
            //ViewData["GroupUpdateId"] = new SelectList(getAllGroupUpdates(), "GroupUpdateId", "GroupUpdateId");
            return View();
        }

        // POST: GroupComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupCommentId,CommentText,GroupUpdateId,CommentDate")] data.GroupComment groupComment)
        {
            if (ModelState.IsValid)
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(baseurl);
                    var content = JsonConvert.SerializeObject(groupComment);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PostAsync("api/GroupComments", byteContent).Result;

                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            ViewData["GroupUpdateId"] = new SelectList(getAllGroupUpdates(), "GroupUpdateId", "GroupUpdateId", groupComment.GroupUpdateId);
            //ViewData["GroupUpdateId"] = new SelectList(_context.GroupUpdates, "GroupUpdateId", "GroupUpdateId", groupComment.GroupUpdateId);
            return View(groupComment);
        }

        // GET: GroupComments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var groupComment = GetById(id);
            if (groupComment == null)
            {
                return NotFound();
            }
            ViewData["GroupUpdateId"] = new SelectList(getAllGroupUpdates(), "GroupUpdateId", "GroupUpdateId", groupComment.GroupUpdateId);
            return View(groupComment);
        }

        // POST: GroupComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupCommentId,CommentText,GroupUpdateId,CommentDate")] data.GroupComment groupComment)
        {
            if (id != groupComment.GroupCommentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    using (var cl = new HttpClient())
                    {
                        cl.BaseAddress = new Uri(baseurl);
                        var content = JsonConvert.SerializeObject(groupComment);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        var postTask = cl.PutAsync("api/GroupComments/" + id, byteContent).Result;

                        if (postTask.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
                catch (Exception)
                {
                    var aux2 = GetById(id);
                    if (aux2 == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupUpdateId"] = new SelectList(getAllGroupUpdates(), "GroupUpdateId", "GroupUpdateId", groupComment.GroupUpdateId);
            // ViewData["GroupUpdateId"] = new SelectList(_context.GroupUpdates, "GroupUpdateId", "GroupUpdateId", groupComment.GroupUpdateId);
            return View(groupComment);
        }

        // GET: GroupComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupComment = GetById(id);
            if (groupComment == null)
            {
                return NotFound();
            }

           
            return View(groupComment);
        }

        // POST: GroupComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using(var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();   
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.DeleteAsync("api/GroupComments/" + id);
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        private bool GroupCommentExists(int id)
        {
            return (GetById(id) != null);
        }

        private data.GroupComment GetById(int? id)
        {
            data.GroupComment aux = new data.GroupComment();
            using(var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res =  cl.GetAsync("api/GroupComments/" + id).Result;
                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<data.GroupComment>(auxres);
                }
            }
            return aux;
        }

        private List<data.GroupUpdate> getAllGroupUpdates()
        {
            List<data.GroupUpdate> aux = new List<data.GroupUpdate>();
            using(var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/GroupUpdates").Result;
                if (res.IsSuccessStatusCode)
                {
                    var auxres =  res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.GroupUpdate>>(auxres);
                }
            }
            return aux;
        }
    }
}
