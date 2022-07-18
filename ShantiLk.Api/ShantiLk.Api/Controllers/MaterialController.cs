using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ShantiLk.Api.Controllers
{
    [Route("/Materials")]
    public partial class MaterialController : Controller
    {
        /// <summary>
        ///     Get list of materials for the current semester
        /// </summary>
        /// <param name="semesterId">(optional) Id needed semester</param>
        /// <param name="subjectId">(optional) Id needed discipline</param>
        /// <returns></returns>
        [Route("GetList")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetMaterials(int semesterId = 0, int subjectId = 0)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetMaterials(semesterId, subjectId).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        /// <summary>
        ///     Download material file
        /// </summary>
        /// <param name="materialHash">Hash material file</param>
        /// <returns></returns>
        [Route("GetFile")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetFile(string materialHash)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetFile(materialHash).Result)); }
            catch (Exception ex) { return Forbid(); }
        }
    }
}
