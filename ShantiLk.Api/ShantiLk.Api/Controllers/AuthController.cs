using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShantiLk.Api.Models.ShantiClasses.Common;

namespace ShantiLk.Api.Controllers
{
    [Controller]
    [Route("/Auth")]
    public partial class AuthController : ControllerBase
    {
        /// <summary>
        ///     Return result of authorization
        /// </summary>
        /// <param name="data">(body) Login and Password from SUAI LK</param>
        /// <returns></returns>
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

        /// <summary>
        ///     Returns result of logout
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [Route("Logout")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActionResult))]
        [ProducesResponseType(403, Type = typeof(void))]
        public ActionResult Logout()
        {
            try { return Content(JsonConvert.SerializeObject(h_Logout().Result)); }
            catch (Exception ex) { return Forbid(); }
        }
    }
}
