using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ShantiLk.Api.Controllers
{
    [Controller]
    [Route("/Profile")]
    public partial class ProfileController : Controller
    {
        [Route("Get")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetTasks()
        {
            try { return Content(JsonConvert.SerializeObject(h_GetProfile().Result)); }
            catch (Exception ex) { return Forbid(); }
        }
    }
}
