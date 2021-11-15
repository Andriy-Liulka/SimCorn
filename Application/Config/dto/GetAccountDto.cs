using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Config.dto
{
    public class GetAccountDto
    {
        [Required]
        public string Portfolio { get; set; }
        [Required]
        public string Instrument_owner { get; set; }
        [Required]
        public string Instrument { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
