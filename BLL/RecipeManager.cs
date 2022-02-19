using Common.Dto;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class RecipeManager
    {
        public List<Recipe> TempRecipies { get; set; }
        public RecipeContext Context { get; set; }


        public RecipeManager(IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RecipeContext>();
            optionsBuilder.UseSqlServer(ConfigurationExtensions.GetConnectionString(configuration, "Default"));

            Context = new RecipeContext(optionsBuilder.Options);
        }

        private void TempData()
        {
            TempRecipies = new List<Recipe>();

            for (int i = 0; i < 4; i++)
            {
                var r1 = new Recipe();
                r1.Name = "Salted Duck....";
                r1.Ingredients = new List<Ingredient>();
                r1.Instructions = new List<Instruction>();
                r1.ImageUrl = "https://www.youtotallygotthis.com/wp-content/uploads/2017/05/Cazuela-Feature-Image-150x150.jpg";

                for (int j = 0; j < 10; j++)
                {
                    r1.Ingredients.Add(new Ingredient { Name = "salt" });
                }

                for (int j = 0; j < 10; j++)
                {
                    r1.Instructions.Add(new Instruction { StepNumber = j, Description = "Season with salt" });
                }

                TempRecipies.Add(r1);
            }
            for (int i = 0; i < 4; i++)
            {
                var r1 = new Recipe();
                r1.Name = "Baked Duck....";
                r1.Ingredients = new List<Ingredient>();
                r1.Instructions = new List<Instruction>();
                r1.ImageUrl = "https://www.youtotallygotthis.com/wp-content/uploads/2017/05/Cazuela-Feature-Image-150x150.jpg";

                for (int j = 0; j < 10; j++)
                {
                    r1.Ingredients.Add(new Ingredient { Name = "salt" });
                }

                for (int j = 0; j < 10; j++)
                {
                    r1.Instructions.Add(new Instruction { StepNumber = j, Description = "Season with salt" });
                }

                TempRecipies.Add(r1);
            }
            for (int i = 0; i < 4; i++)
            {
                var r1 = new Recipe();
                r1.Name = "Fried Duck....";
                r1.Ingredients = new List<Ingredient>();
                r1.Instructions = new List<Instruction>();
                r1.ImageUrl = "https://www.youtotallygotthis.com/wp-content/uploads/2017/05/Cazuela-Feature-Image-150x150.jpg";

                for (int j = 0; j < 10; j++)
                {
                    r1.Ingredients.Add(new Ingredient { Name = "salt" });
                }

                for (int j = 0; j < 10; j++)
                {
                    r1.Instructions.Add(new Instruction { StepNumber = j, Description = "Season with salt" });
                }

                TempRecipies.Add(r1);
            }
        }

        public int Insert(Recipe recipe)
        {
            using (var context = this.Context)
            {
                context.Entry(recipe).State = EntityState.Added;

                if (recipe.Ingredients?.Count > 0)
                {
                    context.AddRange(recipe.Ingredients);
                }

                if (recipe.Instructions?.Count > 0)
                {
                    context.AddRange(recipe.Instructions);
                }

                context.SaveChanges();
            }

            return recipe.RecipeId;
        }

        public List<Recipe> GetRecepies()
        {
            return this.Context.Recipies
                    .Include(i => i.Ingredients)
                    .Include(i => i.Instructions)
                    .ToList();
        }
    }
}
