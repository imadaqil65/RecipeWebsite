using MyApplication.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Web_Application.DTO
{
    public class MainCourseDTO
    {
        [Required(ErrorMessage ="Cuisine type (ex: Mediterranean, Asian, etc) is required"), MinLength(3, ErrorMessage = "Too short")]
        public string cuisineType { get; set; }
        [Required(ErrorMessage ="Serving suggestion (ex: ketchup on the side) is required"), MinLength(3, ErrorMessage = "Too short")]
        public string servingSuggestion { get; set; }
        //public List<Diet> SelectedDiets { get; set; } = new List<Diet>();
    }
}
