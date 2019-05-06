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
                ChurchLocation = model.ChurchLocation,
                CommunityInvolvement = model.CommunityInvolvement,
                Friendliness = model.Friendliness,
                Facilities = model.Facilities,
                Music = model.Music,
                Message = model.Message
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
                        ChurchLocation = p.ChurchLocation,
                        CommunityInvolvement = p.CommunityInvolvement,
                        Friendliness = p.Friendliness,
                        Facilities = p.Facilities,
                        Music = p.Music,
                        Message = p.Message


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
                    ChurchLocation = entity.ChurchLocation,
                    CommunityInvolvement = entity.CommunityInvolvement,
                    Friendliness = entity.Friendliness,
                    Facilities = entity.Facilities,
                    Music = entity.Music,
                    Message = entity.Message
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
                entity.ChurchLocation = model.ChurchLocation;
                entity.CommunityInvolvement = model.CommunityInvolvement;
                entity.Friendliness = model.Friendliness;
                entity.Music = model.Music;
                entity.Message = model.Message;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteChurch(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Churches.Single(p => p.ChurchID == id);

                ctx.Churches.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        }
    }

