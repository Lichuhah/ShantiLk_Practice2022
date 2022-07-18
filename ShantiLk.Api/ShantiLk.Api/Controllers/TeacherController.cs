using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ShantiLk.Api.Controllers
{
    [Route("/Teachers")]
    public partial class TeacherController : Controller
    {
        /// <summary>
        ///     Get teacher info
        /// </summary>
        /// <param name="id">Id needed teacher</param>
        /// <returns></returns>
        [Route("Get")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult Get(int id)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetTeacher(id).Result)); }
            catch (Exception ex) { return Forbid(); }
        }
    }
}
