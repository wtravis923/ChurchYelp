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

        public int CommunityInvolvementRating { get; set; }

        public int FriendlyRating { get; set; }

        public int FacilityRating { get; set; }

        public int MusicRating { get; set; }

        public int MessageRating { get; set; }

        public virtual Church Church { get; set; }

    }
}
