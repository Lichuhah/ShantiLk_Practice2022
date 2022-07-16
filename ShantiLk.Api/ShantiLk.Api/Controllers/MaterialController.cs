using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ShantiLk.Api.Controllers
{
    [Route("/Materials")]
    public partial class MaterialController : Controller
    {
        [Route("GetMaterials")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetMaterials()
        {
            try { return Content(JsonConvert.SerializeObject(h_GetMaterials(null).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        [Route("GetMaterialsBySemester")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetMaterialsBySemester(int SemesterId)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetMaterials(SemesterId).Result)); }
            catch (Exception ex) { return Forbid(); }
        }
    }
}
