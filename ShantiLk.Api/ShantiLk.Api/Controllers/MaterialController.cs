using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ShantiLk.Api.Controllers
{
    [Route("/Materials")]
    public partial class MaterialController : Controller
    {
        [Route("GetList")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetMaterials()
        {
            try { return Content(JsonConvert.SerializeObject(h_GetMaterials().Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        [Route("GetBySemester")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetBySemester(int semesterId)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetMaterials(semesterId).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        [Route("GetBySubject")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetBySubject(int subjectId)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetMaterials(0, subjectId).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

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
