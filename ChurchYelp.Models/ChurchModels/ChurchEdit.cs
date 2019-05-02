using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchYelp.Models
{
  public  class ChurchEdit
    {
        public int ChurchID { get; set; }

        public string ChurchName { get; set; }

        public string ChurchLocation { get; set; }

        public float CommunityInvolvement { get; set; }

        public float Friendliness { get; set; }

        public float Facilities { get; set; }

        public float Music { get; set; }

        public float Message { get; set; }
    }
}
