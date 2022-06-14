using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiCity.DTO;
using WebApiCity.Models;

namespace WebApiCity.Controllers
{

    [AllowAnonymous]
    public class AccessController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Login(UserDTO user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Model is not valid");
            }
            using(WebApiPaisesEntities db =new WebApiPaisesEntities())
            {
                var lst = db.User.Where(x => x.email == user.email && x.password.Equals(user.password,StringComparison.CurrentCultureIgnoreCase)).ToList();
                if (lst.Count() > 0)
                {
                    var token = TokenGenerator.GenerateTokenJwt(user.email);
                    return Ok(token);
                }
                else
                    return Unauthorized(); // status code 401
            }
        }
    }
}
