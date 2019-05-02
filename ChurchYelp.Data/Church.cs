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

        public Guid UserID { get; set; }

        public string ChurchName { get; set; }

        public string ChurchLocation { get; set; }

        public float CommunityInvolvement { get; set; }

        public float Friendliness { get; set; }

        public float Facilities { get; set; }

        public float Music { get; set; }

        public float Message { get; set; }

    }
}
