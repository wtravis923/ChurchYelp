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
        public bool CreateLeader(LeaderCreate model)
        {
            Leader leader = new Leader()
            {
                LeaderName = model.LeaderName,
                SpeakingAbility = model.SpeakingAbility,
                Engaging = model.Engaging,
                Authentic = model.Authentic,
                Rapport = model.Rapport
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
                        SpeakingAbility = p.SpeakingAbility,
                        Engaging = p.Engaging,
                        Authentic = p.Authentic,
                        Rapport = p.Rapport
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
                    SpeakingAbility = entity.SpeakingAbility,
                    Engaging = entity.Engaging,
                    Authentic = entity.Authentic,
                    Rapport = entity.Rapport
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
                entity.SpeakingAbility = model.SpeakingAbility;
                entity.Engaging = model.Engaging;
                entity.Authentic = model.Authentic;
                entity.Rapport = model.Rapport;

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
