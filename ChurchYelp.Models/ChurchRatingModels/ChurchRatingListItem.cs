using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChurchYelp.Data;

namespace ChurchYelp.Models.ChurchRatingModels
{
    public class ChurchRatingListItem
    {
        public int ChurchRatingID { get; set; }

        public int ChurchID { get; set; }

        public string ChurchName { get; set; }
        public string ChurchCity { get; set; }
        public string ChurchState { get; set; }

        public float CommunityInvolvementRating { get; set; }

        public float FriendlyRating { get; set; }

        public float FacilityRating { get; set; }

        public float MusicRating { get; set; }

        public float MessageRating { get; set; }
    }
}
