using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchYelp.Models
{
    public class ChurchCreate
    {
        [Required]
        public string ChurchName { get; set; }

        [Required]
        public string ChurchCity { get; set; }

        [Required]
        public string ChurchState { get; set; }
    }
}
