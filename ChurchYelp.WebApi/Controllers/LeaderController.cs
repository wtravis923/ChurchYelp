using ChurchYelp.Models.LeaderModels;
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
    public class LeaderController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            LeaderService leaderService = CreateLeaderService();
            var leaders = leaderService.GetLeaders();
            return Ok(leaders);
        }

        public IHttpActionResult Get()
        {
            LeaderService leaderService = CreateLeaderService();
            var leaders = leaderService.GetLeaders();
            return Ok(leaders);
        }

        public IHttpActionResult Post(LeaderCreate leader)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateLeaderService();

            if (!service.CreateLeader(leader))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(LeaderEdit leader)
        {
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateLeaderService();
            if (!service.DeleteLeader(id))
                return InternalServerError();

            return Ok();
        }

        //Added a blank constructor in Leader Service to run.
        private LeaderService CreateLeaderService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var leaderService = new LeaderService(userId);
            return leaderService;
        }
        
    }
}
