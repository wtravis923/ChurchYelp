using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChurchYelp.Data;

namespace ChurchYelp.Models.ChurchRatingModels
{
    public class ChurchRatingEdit
    {
        public int ChurchID { get; set; }

        public float CommunityInvolvementRating { get; set; }

        public float FriendlyRating { get; set; }

        public float FacilityRating { get; set; }

        public float MusicRating { get; set; }

        public float MessageRating { get; set; }

        public virtual Church Church { get; set; }
    }
}
