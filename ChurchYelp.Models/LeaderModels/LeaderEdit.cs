using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchYelp.Models.LeaderModels
{
    public class LeaderEdit
    {
        [Required]
        public int LeaderID { get; set; }

        [Required]
        public string LeaderName { get; set; }
    }
}
