using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ChurchYelp.Data
{
    public class Church
    {
        [Key]
        public int ChurchID { get; set; }

        [Required]
        public string ChurchName { get; set; }

        [Required]
        public string ChurchCity { get; set; }

        [Required]
        public string ChurchState { get; set; }


        //Foreign Keys from Church Rating
        public float CommunityInvolvementRating { get; set; }

        public float FriendlyRating { get; set; }

        public float FacilityRating { get; set; }

        public float MusicRating { get; set; }

        public float MessageRating { get; set; }

    }
}
