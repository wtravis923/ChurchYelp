using ChurchYelp.Data;
using ChurchYelp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchYelp.Services
{
    public class ChurchService
    {
        public bool CreateChurch(ChurchCreate model)
        {
            Church church = new Church()
            {
                ChurchName = model.ChurchName,
                ChurchCity = model.ChurchCity,
                ChurchState = model.ChurchState
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Churches.Add(church);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ChurchListItem> GetChurch()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Churches
                    .Select(p => new ChurchListItem
                    {
                        ChurchID = p.ChurchID,
                        ChurchName = p.ChurchName,
                        ChurchCity = p.ChurchCity,
                        ChurchState = p.ChurchState,
                        CommunityInvolvementRating = p.CommunityInvolvementRating,
                        FriendlyRating = p.FriendlyRating,
                        FacilityRating = p.FacilityRating,
                        MusicRating = p.MusicRating,
                        MessageRating = p.MessageRating
                    });
                return query.ToArray();
            }
        }

       public ChurchDetail GetChurchByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Churches.FirstOrDefault(p => p.ChurchID == id);

                var model = new ChurchDetail
                {
                    ChurchID = entity.ChurchID,
                    ChurchName = entity.ChurchName,
                    ChurchCity = entity.ChurchCity,
                    ChurchState = entity.ChurchState,
                    CommunityInvolvementRating = entity.CommunityInvolvementRating,
                    FriendlyRating = entity.FriendlyRating,
                    FacilityRating = entity.FacilityRating,
                    MusicRating = entity.MusicRating,
                    MessageRating = entity.MessageRating
                };
                return model;
            }
        }
        public bool EditChurch(ChurchEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Churches.FirstOrDefault(p => p.ChurchID == model.ChurchID);

                entity.ChurchName = model.ChurchName;
                entity.ChurchCity = model.ChurchCity;
                entity.ChurchState = model.ChurchState;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteChurch(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Churches.Single(p => p.ChurchID == id);

                ctx.Churches.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

