using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ShantiLk.Api.Controllers
{
    [Controller]
    [Route("/Profile")]
    public partial class ProfileController : Controller
    {
        /// <summary>
        ///     Get profile info
        /// </summary>
        /// <returns></returns>
        [Route("Get")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult Get()
        {
            try { return Content(JsonConvert.SerializeObject(h_GetProfile().Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        /// <summary>
        ///     Download education plan file
        /// </summary>
        /// <returns></returns>
        [Route("GetEducationPlan")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetEducationPlan()
        {
            try { return Content(JsonConvert.SerializeObject(h_GetEducationPlan().Result)); }
            catch (Exception ex) { return Forbid(); }
        }
    }
}
