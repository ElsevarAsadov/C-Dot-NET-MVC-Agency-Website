using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Product : BaseEntity
    {
        public string ShowcasePrimaryText { get; set; }
        public string ShowcaseSecondaryText { get; set;}

        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string MiniDescription { get; set; }

        //needs dto
        public string ImageFileName { get; set; } = "";
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [NotMapped]
        public IFormFile ProductImage { get; set; }
    }
}
