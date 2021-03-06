﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ChurchYelp.Data;

namespace ChurchYelp.Models.LeaderRatingModels
{
  public  class LeaderRatingCreate
    {
        public int LeaderID { get; set; }

        public int LeaderRatingID { get; set; }

        public Guid UserID { get; set; }

        public float SpeakingAbilityRating { get; set; }

        public float EngagingRating { get; set; }

        public float AuthenticRating { get; set; }

        public float RapportRating { get; set; }

        public virtual Leader Leaders { get; set; }
    
      
    }
}
