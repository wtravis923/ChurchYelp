using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchYelp.Data
{

 public class Leader

    {
        [Key]
        public int LeaderID { get; set; }

        [Required]
        public string LeaderName { get; set; }

        //Foreign Keys brought in from LeaderRating
        public float SpeakingAbilityRating { get; set; }

        public float EngagingRating { get; set; }

        public float AuthenticRating { get; set; }

        public float RapportRating { get; set; }
    }
}
