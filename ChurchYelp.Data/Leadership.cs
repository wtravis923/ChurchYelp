using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchYelp.Data
{
 public   class Leadership
    {
        [Key]
        public int LeaderID { get; set; }

        public string LeaderName { get; set; }

        public Guid UserID { get; set; }

        public string SpeakingAbility { get; set; }

        public string Engaging { get; set; }

        public string Authentic { get; set; }

        public string Rapport { get; set; }
    }
}
