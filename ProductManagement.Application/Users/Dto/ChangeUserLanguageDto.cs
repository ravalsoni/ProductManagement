using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}