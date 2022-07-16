using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ShantiLk.Api.Controllers
{
    [Route("/Tasks")]
    public partial class TaskController : Controller
    {
        [Route("GetTasks")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetTasks()
        {
            try { return Content(JsonConvert.SerializeObject(h_GetTasks().Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        [Route("GetTask")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetTask(int id)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetTask(id).Result)); }
            catch (Exception ex) { return Forbid(); }
        }
    }
}
