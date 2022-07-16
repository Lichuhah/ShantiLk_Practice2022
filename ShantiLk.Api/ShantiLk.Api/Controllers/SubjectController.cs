using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ShantiLk.Api.Controllers
{
    [Route("/Subjects")]
    public partial class SubjectController : Controller
    {
        [Route("GetTasks")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetTasks()
        {
            try { return Content(JsonConvert.SerializeObject(h_GetSubjects().Result)); }
            catch (Exception ex) { return Forbid(); }
        }
    }
}
