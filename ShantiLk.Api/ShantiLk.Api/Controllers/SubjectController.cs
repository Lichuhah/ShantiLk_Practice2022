using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ShantiLk.Api.Controllers
{
    [Route("/Subjects")]
    public partial class SubjectController : Controller
    {
        /// <summary>
        ///     Get list of disciplines for current semester
        /// </summary>
        /// <param name="controlTypeId">(optional) Id needed control type</param>
        /// <param name="semesterId">(optional) Id needed semester</param>
        /// <returns></returns>
        [Route("GetList")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetList(int semesterId = 0, int controlTypeId = 0)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetSubjects(semesterId, controlTypeId).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        /// <summary>
        ///     Get discipline info
        /// </summary>
        /// <param name="id"> Id needed discipline</param>
        /// <returns></returns>
        [Route("Get")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetTask(int id)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetSubject(id).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        /// <summary>
        ///     Get list tasks for discipline
        /// </summary>
        /// <param name="subjectId"> Id needed discipline</param>
        /// <returns></returns>
        [Route("GetTasks")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetTasks(int subjectId)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetSubjectTasks(subjectId).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        /// <summary>
        ///     Download annotation file for discipline
        /// </summary>
        /// <param name="subjectId"> Id needed discipline</param>
        /// <returns></returns>
        [Route("GetAnnotation")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetAnnotation(int subjectId)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetAnnotation(subjectId).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        /// <summary>
        ///     Download education plan file for discipline
        /// </summary>
        /// <param name="subjectId"> Id needed discipline</param>
        /// <returns></returns>
        [Route("GetEducationPlan")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetEducationPlan(int subjectId)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetEducationPlan(subjectId).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        /// <summary>
        ///     Download work programm file for discipline
        /// </summary>
        /// <param name="subjectId"> Id needed discipline</param>
        /// <returns></returns>
        [Route("GetWorkProgramm")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetWorkProgramm(int subjectId)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetWorkProgramm(subjectId).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        /// <summary>
        ///     Get list materials for discipline
        /// </summary>
        /// <param name="id"> Id needed discipline</param>
        /// <returns></returns>
        [Route("GetMaterials")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetMaterials(int id)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetSubjectMaterials(id).Result)); }
            catch (Exception ex) { return Forbid(); }
        }
    }
}
