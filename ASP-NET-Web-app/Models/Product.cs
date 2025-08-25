using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP_NET_Web_app.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required, StringLength(150)]
        public string ProductName { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }
    }
}