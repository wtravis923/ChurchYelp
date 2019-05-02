using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ChurchYelp.Data;

namespace ChurchYelp.Models.LeaderRatingModels
{
    class LeaderRatingCreate
    {
        public int LeaderID { get; set; }
        public int SpeakingAbilityRating { get; set; }

        public int EngaginRating { get; set; }

        public int AuthenticRating { get; set; }

        public int RapportRating { get; set; }

        public virtual Leadership Leadership { get; set; }
    }
}
