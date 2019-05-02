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
        }
    }

