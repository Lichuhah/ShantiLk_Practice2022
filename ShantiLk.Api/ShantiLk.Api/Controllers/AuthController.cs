using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShantiLk.Api.Models.Common.Auth;

namespace ShantiLk.Api.Controllers
{
    [Route("/Auth")]
    public partial class AuthController : ControllerBase
    {
        [Route("Login")]
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult Login([FromBody] LoginData data)
        {
            try { return Content(JsonConvert.SerializeObject(h_Login(data).Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        [Route("Logout")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult Logout()
        {
            try { return Content(JsonConvert.SerializeObject(h_Logout().Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        [Route("CheckLogin")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [AllowAnonymous]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult CheckLogin()
        {
            try { return Content(JsonConvert.SerializeObject(h_CheckLogin().Result)); }
            catch (Exception ex) { return Forbid(); }
        }

        [Route("Test")]
        [HttpGet]
        public ActionResult Test()
        {
            return Content("good");
        }
    }
}
