using ChurchYelp.Models.ChurchRatingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChurchYelp.Data;

namespace ChurchYelp.Services
{
    public class ChurchRatingService
    {
        private readonly Guid _userId;

        public ChurchRatingService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRating(ChurchRatingCreate model)
        {
            var rating = new ChurchRating
            {
                ChurchID = model.ChurchID,
                CommunityInvolvementRating = model.CommunityInvolvementRating,
                FriendlyRating = model.FriendlyRating,
                FacilityRating = model.FacilityRating,
                MusicRating = model.MusicRating,
                MessageRating = model.MessageRating,
                UserID = _userId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ChurchRatings.Add(rating);
                if (ctx.SaveChanges() == 1)
                {
                    CalculateCommunityInvolvement(rating.ChurchID);
                    CalculateFriendly(rating.ChurchID);
                    CalculateFacility(rating.ChurchID);
                    CalculateMusic(rating.ChurchID);
                    CalculateMessage(rating.ChurchID);
                    return true;
                }
                return false;
            }
        }

        public IEnumerable<ChurchRatingListItem>
            GetRatingsByChurchID(int churchId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .ChurchRatings
                    .Where(r => r.ChurchID == churchId)
                    .Select(r => new ChurchRatingListItem
                    {
                        ChurchRatingID = r.ChurchRatingID,
                        ChurchID = r.ChurchID,
                        CommunityInvolvementRating = r.CommunityInvolvementRating,
                        FriendlyRating = r.FriendlyRating,
                        FacilityRating = r.FacilityRating,
                        MusicRating = r.MusicRating,
                        MessageRating = r.MessageRating,

                    }).ToArray();
                return query;
            }
        }

        public ChurchRatingDetail GetRatingByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.ChurchRatings.Single(r => r.ChurchRatingID == id);

                var model = new ChurchRatingDetail
                {
                    ChurchRatingID = entity.ChurchRatingID,
                    ChurchID = entity.ChurchID,
                    ChurchName = entity.Church.ChurchName,
                    CommunityInvolvementRating = entity.CommunityInvolvementRating,
                    FriendlyRating = entity.FriendlyRating,
                    FacilityRating = entity.FacilityRating,
                    MusicRating = entity.MusicRating,
                    MessageRating = entity.MessageRating
                };

                return model;
            }
        }
        public bool EditChurchRating(ChurchRatingEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.ChurchRatings.Single(r => r.ChurchRatingID == model.ChurchRatingID);

                entity.CommunityInvolvementRating = model.CommunityInvolvementRating;
                entity.FriendlyRating = model.FriendlyRating;
                entity.FacilityRating = model.FacilityRating;
                entity.MusicRating = model.MusicRating;
                entity.MessageRating = model.MusicRating;
                entity.ChurchID = model.ChurchID;

                if (ctx.SaveChanges() == 1)
                {
                    CalculateCommunityInvolvement(model.ChurchID);
                    CalculateFriendly(model.ChurchID);
                    CalculateFacility(model.ChurchID);
                    CalculateMusic(model.ChurchID);
                    CalculateMessage(model.ChurchID);
                    return true;
                }
                return false;
            }
        }

        public bool DeleteChurhcRating(int ratingId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.ChurchRatings.Single(r => r.ChurchRatingID == ratingId);

                ctx.ChurchRatings.Remove(entity);

                if (ctx.SaveChanges() == 1)
                {
                    CalculateCommunityInvolvement(entity.ChurchID);
                    CalculateFriendly(entity.ChurchID);
                    CalculateFacility(entity.ChurchID);
                    CalculateMusic(entity.ChurchID);
                    CalculateMessage(entity.ChurchID);
                    return true;
                }
                return false;
            }
        }
        private bool CalculateCommunityInvolvement(int churchId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.ChurchRatings.Where(r => r.ChurchID == churchId).ToList();

                float totalCommunity = 0;
                foreach (var rating in query)
                {
                    totalCommunity += rating.CommunityInvolvementRating;
                }
                totalCommunity /= query.Count;

                var church = ctx.Churches.Single(p => p.ChurchID == churchId);
                church.CommunityInvolvementRating = totalCommunity;

                return ctx.SaveChanges() == 1;
            }
        }
        private bool CalculateFriendly(int churchId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.ChurchRatings.Where(r => r.ChurchID == churchId).ToList();

                float totalFriendly = 0;
                foreach (var rating in query)
                {
                    totalFriendly += rating.FriendlyRating;
                }
                totalFriendly /= query.Count;

                var church = ctx.Churches.Single(p => p.ChurchID == churchId);
                church.FriendlyRating = totalFriendly;

                return ctx.SaveChanges() == 1;
            }
        }
        private bool CalculateMessage(int churchId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.ChurchRatings.Where(r => r.ChurchID == churchId).ToList();

                float totalMessage = 0;
                foreach (var rating in query)
                {
                    totalMessage += rating.MessageRating;
                }
                totalMessage /= query.Count;

                var church = ctx.Churches.Single(p => p.ChurchID == churchId);
                church.MessageRating = totalMessage;

                return ctx.SaveChanges() == 1;
            }
        }
        private bool CalculateMusic(int churchId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.ChurchRatings.Where(r => r.ChurchID == churchId).ToList();

                float totalMusic = 0;
                foreach (var rating in query)
                {
                    totalMusic += rating.MusicRating;
                }
                totalMusic /= query.Count;

                var church = ctx.Churches.Single(p => p.ChurchID == churchId);
                church.MusicRating = totalMusic;

                return ctx.SaveChanges() == 1;
            }
        }
        private bool CalculateFacility(int churchId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.ChurchRatings.Where(r => r.ChurchID == churchId).ToList();

                float totalFacility = 0;
                foreach (var rating in query)
                {
                    totalFacility += rating.FacilityRating;
                }
                totalFacility /= query.Count;

                var church = ctx.Churches.Single(p => p.ChurchID == churchId);
                church.FacilityRating = totalFacility;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}


