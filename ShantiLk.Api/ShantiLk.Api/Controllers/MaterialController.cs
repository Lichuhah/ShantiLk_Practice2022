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
        public ActionResult GetBySemester(int SemesterId)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetMaterials(SemesterId).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        [Route("GetBySubject")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetBySubject(int SubjectId)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetMaterials(0, SubjectId).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        [Route("GetFile")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetFile(string MaterialHash)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetFile(MaterialHash).Result)); }
            catch (Exception ex) { return Forbid(); }
        }
    }
}
