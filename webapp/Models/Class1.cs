using System;
using System.ComponentModel.DataAnnotations;

namespace webapp.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Required]
        public string ShortName { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public int ShelfNumber { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required(ErrorMessage = "Date in is required")]
        public DateTime DateIn { get; set; }
        [Required(ErrorMessage = "Date out is required")]
        public DateTime DateOut { get; set; }

    }
}