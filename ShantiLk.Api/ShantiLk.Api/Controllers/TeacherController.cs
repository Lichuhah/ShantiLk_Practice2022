using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShantiLk.Api.Models.ShantiClasses.Teacher;

namespace ShantiLk.Api.Controllers
{
    [Route("/Teachers")]
    public partial class TeacherController : Controller
    {
        [Route("Get")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetTask(int id)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetTeacher(id).Result)); }
            catch (Exception ex) { return Forbid(); }
        }
    }
}
