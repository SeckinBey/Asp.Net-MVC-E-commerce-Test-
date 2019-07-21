using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.MvcWebUI.Entity
{
    public class Category
    {
        public int Id { get; set; }

        //Data annotations
        [DisplayName("Category Name")]
        [StringLength(maximumLength:20,ErrorMessage = "You can enter up to 20 characters.")]
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Product> Products { get; set; } 
    }
}