using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShantiLk.Api.Models.ShantiClasses.Task;

namespace ShantiLk.Api.Controllers
{
    [Route("/Tasks")]
    public partial class TaskController : Controller
    {
        [Route("GetTasks")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetTasks(int SemesterId = 0, int SubjectId = 0, int TypeId = 0, int StatusId = 0)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetTasks(SemesterId, SubjectId, TypeId, StatusId).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        [Route("GetTask")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetTask(int id)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetTask(id).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        [Route("GetMaterial")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetMaterial(int SubjectId)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetMaterialForTask(SubjectId).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        [Route("GetReports")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetReports(int SubjectId)
        {
            try { return Content(JsonConvert.SerializeObject(h_GetReportsForTask(SubjectId).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        [Route("GetReport")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetReport(string ReportHash)
        {
            try { return Content(JsonConvert.SerializeObject(h_DownloadReport(ReportHash).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        [Route("AddReport")]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult AddReport(int taskId, [FromBody] NewReport report)
        {
            try { return Content(JsonConvert.SerializeObject(h_AddReport(taskId, report).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

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
