using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using BLL;
using Common.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipies.Models;

namespace Recipies.Controllers
{
    public class HomeController : Controller
    {

        public RecipeManager Manager { get; private set; }
        public IHostingEnvironment HostEnv { get; private set; }

        public HomeController(RecipeManager _manager, IHostingEnvironment _env)
        {
            Manager = _manager;
            HostEnv = _env;
        }

        public IActionResult Index()
        {
            //return View(Manager.GetRecepies());
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult GetRecipies()
        {
            return Ok(Manager.GetRecepies());
        }

        [HttpPost]
        public IActionResult SaveRecipe()
        {
            var recipe = new Common.Dto.Recipe();

            var upFile = Request.Form.Files[0];
            var filePath = "/Uploads/" + upFile.Name;
            var path = HostEnv.WebRootPath + filePath;

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                upFile.CopyTo(fs);
            }

            recipe.ImageUrl = filePath;
            recipe.Name = Request.Form["Name"];
            recipe.Description = Request.Form["Description"];

            var ingredients = Request.Form["Ingredients"].ToString().Split(new char[] {',' });
            var steps = Request.Form["Steps"].ToString().Split(new char[] { ',' });

            if (ingredients != null && ingredients.Length > 0)
            {
                recipe.Ingredients = new List<Ingredient>();
                foreach (var item in ingredients)
                {
                    recipe.Ingredients.Add(new Ingredient { Name = item });
                }
            }

            if (steps != null && steps.Length > 0)
            {
                recipe.Instructions = new List<Instruction>();
                foreach (var item in steps)
                {
                    recipe.Instructions.Add(new Instruction { Description = item });
                }
            }
            
            Manager.Insert(recipe);

            return Ok();
        }
    }
}
