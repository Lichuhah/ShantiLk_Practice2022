using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShantiLk.Api.Models.ShantiClasses.Common;

namespace ShantiLk.Api.Controllers
{
    [Controller]
    [Route("/Github")]
    public partial class GitHubController : Controller
    {
        [Route("Login")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult Login(string code)
        {
            try { return Content(JsonConvert.SerializeObject(h_Login(code).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        [Route("GetCode")]
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetCode(string code)
        {
            try { return Content(code); }
            catch (Exception ex) { return Forbid(); }
        }

        [Route("GetUrl")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetUrl()
        {
            try { return Content(JsonConvert.SerializeObject(h_GetUrl().Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        [Route("GetRepositories")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult GetRepositories()
        {
            try { return Content(JsonConvert.SerializeObject(h_GetRepositories().Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        [Route("SyncTasks")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult SyncRep(int repositoryId, int semesterId)
        {
            try { return Content(JsonConvert.SerializeObject(h_SyncTasks(repositoryId, semesterId).Result)); }
            catch (Exception ex) { return Forbid(); }
        }
    }
}
