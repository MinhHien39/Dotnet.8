﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LearnDotNet8.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(30)]
        public string CategoryName { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100 , ErrorMessage ="Display Order must be between 1 - 100")]
        public int DisplayOrder {  get; set; }

    }
}
