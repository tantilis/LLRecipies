using System.ComponentModel.DataAnnotations;

namespace Common.Dto
{
    public class Ingredient
    {
        //public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
