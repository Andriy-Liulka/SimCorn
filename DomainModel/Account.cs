using System;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public sealed class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Portfolio { get; set; }
        [Required]
        public string Instrument_owner { get; set; }
        [Required]
        public string Instrument { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
