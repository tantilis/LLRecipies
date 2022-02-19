using Common.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace DAL
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions options)
            : base(options)
        { }
        
        public RecipeContext()                    
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = BLACKBOX\SQLEXPRESS; Database = RecipiesDev; Trusted_Connection = True");
        }

        public DbSet<Recipe> Recipies { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Instruction> Instructions { get; set; }
    }
}
