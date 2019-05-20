using ChurchYelp.Models;
using ChurchYelp.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChurchYelp.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ChurchController : ApiController
    {
        public IHttpActionResult Get()
        {
            ChurchService churchService = new ChurchService();
            var churches = churchService.GetChurch();
            return Ok(churches);
        }

        public IHttpActionResult GetChurchByID(int id)
        {
            ChurchService churchService = new ChurchService();
            var church = churchService.GetChurchByID(id);
            return Ok(church);
        }

        public IHttpActionResult Post(ChurchCreate church)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new ChurchService();

            if (!service.CreateChurch(church))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Put(ChurchEdit church)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new ChurchService();

            if (!service.EditChurch(church))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = new ChurchService();

            if (!service.DeleteChurch(id))
                return InternalServerError();
            return Ok();
        }
        
        
    }

}
