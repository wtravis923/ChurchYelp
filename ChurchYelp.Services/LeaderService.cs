using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChurchYelp.Data;
using ChurchYelp.Models.LeaderModels;

namespace ChurchYelp.Services
{
    public class LeaderService
    {
        public LeaderService(Guid userId)
        {
        }

        public bool CreateLeader(LeaderCreate model)
        {
            Leader leader = new Leader()
            {
                LeaderName = model.LeaderName,
                SpeakingAbilityRating = model.SpeakingAbilityRating,
                EngagingRating = model.EngagingRating,
                AuthenticRating = model.AuthenticRating,
                RapportRating = model.RapportRating
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Leaders.Add(leader);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LeaderListItem> GetLeaders()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Leaders
                    .Select(p => new LeaderListItem
                    {
                        LeaderID = p.LeaderID,
                        LeaderName = p.LeaderName,
                        SpeakingAbilityRating = p.SpeakingAbilityRating,
                        EngagingRating = p.EngagingRating,
                        AuthenticRating = p.AuthenticRating,
                        RapportRating = p.RapportRating
                    });

                return query.ToArray();
            }
        }

        public LeaderDetail GetLeaderByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Leaders.FirstOrDefault(p => p.LeaderID == id);

                var model = new LeaderDetail
                {
                    LeaderID = entity.LeaderID,
                    LeaderName = entity.LeaderName,
                    SpeakingAbilityRating = entity.SpeakingAbilityRating,
                    EngagingRating = entity.EngagingRating,
                    AuthenticRating = entity.AuthenticRating,
                    RapportRating = entity.RapportRating
                };

                return model;
            }
        }

        public bool EditLeader(LeaderEdit model)
        {
            using ( var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Leaders.FirstOrDefault(p => p.LeaderID == model.LeaderID);

                entity.LeaderName = model.LeaderName;
                entity.SpeakingAbilityRating = model.SpeakingAbilityRating;
                entity.EngagingRating = model.EngagingRating;
                entity.AuthenticRating = model.AuthenticRating;
                entity.RapportRating = model.RapportRating;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteLeader (int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Leaders.Single(p => p.LeaderID == id);

                ctx.Leaders.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }


}
