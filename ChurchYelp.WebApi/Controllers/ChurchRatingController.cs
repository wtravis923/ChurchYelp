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
    [Authorize]
    public class ChurchRatingController : ApiController
    {
        public IHttpActionResult GetByChurchId(int id)
        {
            var service = GetChurchRatingService();
            var ratings = service.GetRatingsByChurchID(id);
            return Ok(ratings);
        }

        public IHttpActionResult GetById(int id)
        {
            var service = GetChurchRatingService();
            var church = service.GetRatingByID(id);
            return Ok(church);
        }
        private ChurchRatingService GetChurchRatingService()
        {
            return new ChurchRatingService(Guid.Parse(User.Identity.GetUserId()));
        }
    }
}