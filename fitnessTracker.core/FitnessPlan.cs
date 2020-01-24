using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace fitnessTracker.core
{
    public class FitnessPlan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Pushups { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 8)]
        public string CustomerName { get; set; }
    }
}
