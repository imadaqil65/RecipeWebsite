using System.ComponentModel.DataAnnotations;

namespace Web_Application.DTO
{
    public class DessertDTO
    {
        [Required(ErrorMessage = "Dessert type (ex: Frozen, Cake, etc) required"), MinLength(3, ErrorMessage = "Too short")]
        public string dessertType { get; set; }
        [Required(ErrorMessage = "Serving method (ex: chilled, warm, etc) required"), MinLength(3, ErrorMessage = "Too short")]
        public string servingMethod { get; set; }
        public string topping { get; set; }
    }
}
