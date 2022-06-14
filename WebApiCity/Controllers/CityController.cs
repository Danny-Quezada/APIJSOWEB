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
    [Authorize]
    public class CityController : ApiController
    {
        public IHttpActionResult Get()
        {

            List<CityDTO> list = new List<CityDTO>();
            using (WebApiPaisesEntities db = new WebApiPaisesEntities())
            {
                list = (from p in db.Paises
                        select new DTO.CityDTO
                        {
                            id = p.id,
                            name = p.name
                        }).ToList();

                return Ok(list);
            }
        }
    }
}
