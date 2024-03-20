using System.ComponentModel.DataAnnotations;

namespace Web_Application.DTO
{
	public class DrinkDTO
	{
        public bool alcoholic { get; set; } = false;
        [Required(ErrorMessage = "Drink type (ex: Hot, Cold, etc) is required"), MinLength(3, ErrorMessage = "Too short")]
        public string drinkType { get; set; }
        [Required(ErrorMessage = "Glass type (ex: wine glass, tea cup, etc) is required"), MinLength(3, ErrorMessage = "Too short")]
        public string glassType { get; set; }
    }
}
