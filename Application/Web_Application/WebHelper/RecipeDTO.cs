using Microsoft.AspNetCore.Mvc;
using MyApplication.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Web_Application.DTO
{
    public class RecipeDTO
    {
        public int Id { get; set; }
        public IFormFile image { get; set; }
        [Required(ErrorMessage ="Recipe name is required"), MinLength(3)] public string? recipeName { get; set; }
        [Required(ErrorMessage = "Description is required")] public string? description { get; set; }
        [Required] public recipetype Recipetype { get; set; }
        [Required(ErrorMessage = "Ingredients are required")] public string? ingredients { get; set; }
        [Required(ErrorMessage = "Preparation time is required"), Range(1,1440, ErrorMessage ="Preparation time needs to be between 1 minute to 1440 minutes(24 hours)")] public int preptime { get; set; }
        [Required(ErrorMessage = "Cooking time is required"), Range(1, 1440, ErrorMessage = "Preparation time needs to be between 1 minute to 1440 minutes(24 hours)")] public int cooktime { get; set; }
        [Required(ErrorMessage = "Steps are required"), MinLength(10)] public string? steps { get; set; }

    }
}
