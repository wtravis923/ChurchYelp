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

        [Required]
        public Guid UserID { get; set; }

        [Key]
        public int ChurchRatingID { get; set; }

        [Required]
        public float CommunityInvolvementRating { get; set; }

        [Required]
        public float FriendlyRating { get; set; }

        [Required]
        public float FacilityRating { get; set; }

        [Required]
        public float MusicRating { get; set; }

        [Required]
        public float MessageRating { get; set; }

        [Required]
        public int ChurchID { get; set; }

        public virtual Church Church { get; set; }

    }
}
