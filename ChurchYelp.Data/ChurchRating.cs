using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchYelp.Data
{
    public class ChurchRating
    {
        [Key]
        public int ChurchID { get; set; }
        public Guid UserID { get; set; }
        public int ChurchRatingID { get; set; }

        public float CommunityInvolvementRating { get; set; }

        public float FriendlyRating { get; set; }

        public float FacilityRating { get; set; }

        public float MusicRating { get; set; }

        public float MessageRating { get; set; }

        public virtual Church Church { get; set; }

    }
}
