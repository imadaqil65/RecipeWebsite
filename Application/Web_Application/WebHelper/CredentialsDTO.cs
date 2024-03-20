using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Web_Application.DTO
{
	public class CredentialsDTO
	{
        public int Id { get; set; }
        [Required, EmailAddress]
        public string email { get; set; } = string.Empty;
        [Required, MinLength(6, ErrorMessage = "Username must be at least 6 characters long"), MaxLength(18, ErrorMessage = "Password can't exceed 18 characters long")]
        public string username { get; set; } = string.Empty;
        [Required, MinLength(8, ErrorMessage = "Password must be at least 8 characters long"), MaxLength(18, ErrorMessage = "Password can't exceed 18 characters long")]
        public string password { get; set; } = string.Empty;
        [Required] 
        public string firstname { get; set; } = string.Empty;
        public string? middlename { get; set; }
        [Required] 
        public string lastname { get; set; } = string.Empty;
        
    }
}
