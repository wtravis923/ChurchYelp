using ChurchYelp.Data;
using ChurchYelp.Models.LeaderRatingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchYelp.Services
{
    public class LeaderRatingService
    {
        private readonly Guid _userId;

        public LeaderRatingService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRating(LeaderRatingCreate model)
        {
            var rating = new LeaderRating
            {
                LeaderID = model.LeaderID,
                SpeakingAbilityRating = model.SpeakingAbilityRating,
                EngaginRating = model.EngagingRating,
                AuthenticRating = model.AuthenticRating,
                RapportRating = model.RapportRating,
                UserID = model.UserID
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.LeaderRatings.Add(rating);
                if (ctx.SaveChanges() == 1)
                {
                    CalculateSpeakingAbilityRating(rating.LeaderID);
                    CalculateEngagingRating(rating.LeaderID);
                    CalculateAuthenticRating(rating.LeaderID);
                    CalculateRapportRating(rating.LeaderID);
                    return true;
                }
                return false;
            }
        }

        public IEnumerable<LeaderRatingListItem> GetRatingsByLeaderID(int leaderID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .LeaderRatings
                    .Where(r => r.LeaderID == leaderID)
                    .Select(r => new LeaderRatingListItem
                    {
                        LeaderRatingID = r.LeaderRatingID,
                        LeaderID = r.LeaderID,
                        SpeakingAbilityRating = r.SpeakingAbilityRating,
                        EngagingRating = r.EngaginRating,
                        AuthenticRating = r.AuthenticRating,
                        RapportRating = r.RapportRating,
                    }).ToArray();
                return query;
            }
        }
        public LeaderRatingDetail GetRatingsByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.LeaderRatings.Single(r => r.LeaderRatingID == id);

                var model = new LeaderRatingDetail
                {
                    LeaderRatingID = entity.LeaderRatingID,
                    LeaderID = entity.LeaderID,
                    SpeakingAbilityRating = entity.SpeakingAbilityRating,
                    EngagingRating = entity.EngaginRating,
                    AuthenticRating = entity.AuthenticRating,
                    RapportRating = entity.RapportRating


                };

                return model;
            }
        }
        public bool EditLeaderRating(LeaderRatingEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.LeaderRatings.Single(r => r.LeaderRatingID == model.LeaderRatingID);

                entity.SpeakingAbilityRating = model.SpeakingAbilityRating;
                entity.EngaginRating = model.EngagingRating;
                entity.AuthenticRating = model.AuthenticRating;
                entity.RapportRating = model.RapportRating;

                if (ctx.SaveChanges() == 1)
                {
                    CalculateSpeakingAbilityRating(model.LeaderID);
                    CalculateEngagingRating(model.LeaderID);
                    CalculateAuthenticRating(model.LeaderID);
                    CalculateRapportRating(model.LeaderID);
                    return true;
                }
                return false;
            }
        }
        public bool DeleteLeaderRating(int ratingId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.LeaderRatings.Single(r => r.LeaderRatingID == ratingId);

                ctx.LeaderRatings.Remove(entity);

                if (ctx.SaveChanges() == 1)
                {
                    CalculateSpeakingAbilityRating(entity.LeaderID);
                    CalculateEngagingRating(entity.LeaderID);
                    CalculateAuthenticRating(entity.LeaderID);
                    CalculateRapportRating(entity.LeaderID);
                    return true;
                }
                return false;
            }
        }

        private bool CalculateSpeakingAbilityRating(int leaderId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.LeaderRatings.Where(r => r.LeaderID == leaderId).ToList();

                float totalRating = 0;
                foreach (var rating in query)
                {
                    totalRating += rating.SpeakingAbilityRating;
                }
                totalRating /= query.Count;

                var leader = ctx.Leaders.Single(p => p.LeaderID == leaderId);
                leader.SpeakingAbility = totalRating;

                return ctx.SaveChanges() == 1;
            }
        }
        private bool CalculateEngagingRating(int leaderId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.LeaderRatings.Where(r => r.LeaderID == leaderId).ToList();

                float totalRating = 0;
                foreach (var rating in query)
                {
                    totalRating += rating.EngaginRating;
                }
                totalRating /= query.Count;

                var leader = ctx.Leaders.Single(p => p.LeaderID == leaderId);
                leader.Engaging = totalRating;

                return ctx.SaveChanges() == 1;
            }
        }

        private bool CalculateAuthenticRating(int leaderId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.LeaderRatings.Where(r => r.LeaderID == leaderId).ToList();

                float totalRating = 0;
                foreach (var rating in query)
                {
                    totalRating += rating.AuthenticRating;
                }
                totalRating /= query.Count;

                var leader = ctx.Leaders.Single(p => p.LeaderID == leaderId);
                leader.Authentic = totalRating;

                return ctx.SaveChanges() == 1;
            }
        }
        private bool CalculateRapportRating(int leaderId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.LeaderRatings.Where(r => r.LeaderID == leaderId).ToList();

                float totalRating = 0;
                foreach (var rating in query)
                {
                    totalRating += rating.RapportRating;
                }
                totalRating /= query.Count;

                var leader = ctx.Leaders.Single(p => p.LeaderID == leaderId);
                leader.Rapport = totalRating;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

