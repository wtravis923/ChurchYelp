using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChurchYelp.Models.LeaderRatingModels;
using ChurchYelp.Services;
using Microsoft.AspNet.Identity;

namespace ChurchYelp.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LeaderRatingController : ApiController
    {
        public IHttpActionResult GetByLeaderId(int id)
        {
            var service = GetLeaderRatingService();
            var ratings = service.GetRatingsByLeaderID(id);
            return Ok(ratings);
        }

        public IHttpActionResult GetById(int id)
        {
            var service = GetLeaderRatingService();
            var leader = service.GetRatingsByID(id);
            return Ok(leader);
        }

        public IHttpActionResult Post(LeaderRatingCreate rating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = GetLeaderRatingService();

            if (!service.CreateRating(rating))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(LeaderRatingEdit rating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = GetLeaderRatingService();

            if (!service.EditLeaderRating(rating))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete (int id)
        {
            var service = GetLeaderRatingService();

            if (!service.DeleteLeaderRating(id))
                return InternalServerError();

            return Ok();
        }

        private LeaderRatingService GetLeaderRatingService()
        {
            return new LeaderRatingService(Guid.Parse(User.Identity.GetUserId()));
        }

    }
}
