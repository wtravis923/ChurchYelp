﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchYelp.Data
{
  public class LeadershipRating
    {
        [Key]
        public int LeaderID { get; set; }

        public float SpeakingAbilityRating { get; set; }

        public float EngaginRating { get; set; }

        public float AuthenticRating { get; set; }

        public float RapportRating { get; set; }

        public virtual Leadership Leadership { get; set; }

    }
}
