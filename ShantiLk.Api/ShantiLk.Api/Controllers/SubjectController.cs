using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ShantiLk.Api.Controllers
{
    [Route("/Subjects")]
    public partial class SubjectController : Controller
    {
        [Route("GetList")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetList(int SemesterId = 0, int ControlTypeId = 0)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetSubjects(SemesterId, ControlTypeId).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        [Route("Get")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetTask(int id)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetSubject(id).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        [Route("GetTasks")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetTasks(int SubjectId)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetSubjectTasks(SubjectId).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        [Route("GetAnnotation")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetAnnotation(int SubjectId)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetAnnotation(SubjectId).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        [Route("GetEducationPlan")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetEducationPlan(int SubjectId)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetEducationPlan(SubjectId).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        [Route("GetWorkProgramm")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetWorkProgramm(int SubjectId)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetWorkProgramm(SubjectId).Result)); }
            catch (Exception ex) { return Forbid(); }
        }


        [Route("GetMaterials")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetMaterials(int SubjectId)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetSubjectMaterials(SubjectId).Result)); }
            catch (Exception ex) { return Forbid(); }
        }
    }
}
