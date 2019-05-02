using ChurchYelp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchYelp.Models.LeaderRatingModels
{
    class LeaderRatingEdit
    {
        
        public int LeaderID { get; set; }
        public float SpeakingAbilityRating { get; set; }

        public float EngaginRating { get; set; }

        public float AuthenticRating { get; set; }

        public float RapportRating { get; set; }

        public virtual Leader Leadership { get; set; }
    }
}
