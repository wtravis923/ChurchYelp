using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChurchYelp.Data;


namespace ChurchYelp.Models.ChurchRatingModels
{
    public class ChurchRatingCreate
    {
        [Required]
        public int ChurchID { get; set; }

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
    }
}
