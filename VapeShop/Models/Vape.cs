using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using VapeShop.CustomValidation;
using Microsoft.AspNetCore.Mvc;

namespace VapeShop.Models
{
    public class Vape
    {
        public int VapeId { get; set; }
        [Required]
        [Remote(action: "ValidateName", controller: "Admin")]
        public string Name { get; set; }
        [Min10ShortDesc]
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string AllergyInformation { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsVapeOfTheWeek { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<VapeLiquid> VapeLiquids { get; set; }
    }
}
