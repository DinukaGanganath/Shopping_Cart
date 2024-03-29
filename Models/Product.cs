﻿using Microsoft.AspNetCore.Http;
using Shopping_Cart.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping_Cart.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required, MinLength(2, ErrorMessage = "Need at least 2 characters.")]
        public string Name { get; set; }
        public string Slug { get; set; }
        [Required, MinLength(4, ErrorMessage = "Need at least 4 characters.")]
        public string Description { get; set; }
        [Column(TypeName ="decimal(18, 2)")]
        public decimal Price { get; set; }
        [Display(Name = "Category")]
        [Range(1, int.MaxValue, ErrorMessage ="You must choose a category")]
        public int CategoryId { get; set; }
        
        public string Image { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        [NotMapped]
        [FileExtension]
        public IFormFile ImageUpload { get; set; }
    }
}
