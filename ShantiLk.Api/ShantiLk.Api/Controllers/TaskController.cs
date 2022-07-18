using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShantiLk.Api.Models.ShantiClasses.Task;

namespace ShantiLk.Api.Controllers
{
    [Route("/Tasks")]
    public partial class TaskController : Controller
    {
        /// <summary>
        ///     Get list of tasks for current semester
        /// </summary>
        /// <param name="semesterId">(optional) Id needed semester</param>
        /// <param name="statusId">(optional) Id needed status task</param>
        /// <param name="subjectId">(optional) Id needed discipline</param>
        /// <param name="typeId">(optional) Id needed type task</param>
        /// <returns></returns>
        [Route("GetTasks")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetTasks(int semesterId = 0, int subjectId = 0, int typeId = 0, int statusId = 0)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetTasks(semesterId, subjectId, typeId, statusId).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        /// <summary>
        ///     Get task info
        /// </summary>
        /// <param name="id">Id needed task</param>
        /// <returns></returns>
        [Route("GetTask")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetTask(int id)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetTask(id).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        /// <summary>
        ///     Download task material file
        /// </summary>
        /// <param name="subjectId">Id needed task</param>
        /// <returns></returns>
        [Route("GetMaterial")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetMaterial(int subjectId)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetMaterialForTask(subjectId).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        /// <summary>
        ///     Get list of reports for task
        /// </summary>
        /// <param name="subjectId">Id needed task</param>
        /// <returns></returns>
        [Route("GetReports")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetReports(int taskId)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetReportsForTask(taskId).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        /// <summary>
        ///     Download report file
        /// </summary>
        /// <param name="reportHash">Hash report hash</param>
        /// <returns></returns>
        [Route("GetReport")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetReport(string reportHash)
        {
            try { return Content(JsonConvert.SerializeObject(h_DownloadReport(reportHash).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        /// <summary>
        ///     Add new report for task
        /// </summary>
        /// <param name="taskId">Id needed task</param>
        /// <param name="report">(body) Comment, file name, byte array file</param>
        /// <returns></returns>
        [Route("AddReport")]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult AddReport(int taskId, [FromBody] NewReport report)
        {
            try { return Content(JsonConvert.SerializeObject(h_AddReport(taskId, report).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        /// <summary>
        ///     Delete report
        /// </summary>
        /// <param name="reportId">Id needed report</param>
        /// <returns></returns>
        [Route("DeleteReport")]
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult DeleteReport(int reportId)
        {
            try { return Content(JsonConvert.SerializeObject(h_DeleteReport(reportId).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

    }
}
