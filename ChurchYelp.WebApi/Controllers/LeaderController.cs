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
    [Authorize(Roles ="Admin")]
    public class LeaderController : ApiController
    {
        public IHttpActionResult Get()
        {
            var service = new LeaderService();
            var leader = service.GetLeaders();
            return Ok(leader);
        }
        public IHttpActionResult GetLeaderByID(int id)
        {
            var service = new LeaderService();
            var leader = service.GetLeaderByID(id);
            return Ok(leader);
        }

        public IHttpActionResult Post(LeaderCreate leader)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new LeaderService();

            if (!service.CreateLeader(leader))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(LeaderEdit leader)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new LeaderService();

            if (!service.EditLeader(leader))
                return InternalServerError();

            return Ok();

        }

        public IHttpActionResult Delete(int id)
        {
            var service = new LeaderService();
            if (!service.DeleteLeader(id))
                return InternalServerError();

            return Ok();
        }

        //private LeaderService CreateLeaderService()
        //{
        //    var userId = Guid.Parse(User.Identity.GetUserId());
        //    var leaderService = new LeaderService(userId);
        //    return leaderService;
        //}
        
    }
}
