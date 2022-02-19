using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Dto
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Instruction> Instructions { get; set; }

        [Required]
        [MaxLength(255)]
        public string ImageUrl { get; set; }
    }
}
