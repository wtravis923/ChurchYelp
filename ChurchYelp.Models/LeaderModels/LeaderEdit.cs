using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchYelp.Models.LeaderModels
{
    public class LeaderEdit
    {
        public int LeaderID { get; set; }

        public string LeaderName { get; set; }

        public Guid UserID { get; set; }

        public float SpeakingAbility { get; set; }

        public float Engaging { get; set; }

        public float Authentic { get; set; }

        public float Rapport { get; set; }
    }
}
