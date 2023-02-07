using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MinecraftStore.Models
{
    public class _Contact
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać imię!")]
        public string Name { get; set; }
        [RegularExpression(".+\\@.+\\.[a-z]{2,3}")]
        [Required(ErrorMessage = "Proszę podać poprawny eamil!")]
        public string Email { get; set; }
        public string Subject { get; set; }
        [MinLength(length: 5, ErrorMessage = "Twoja wiadomość musi mieć co najmniej 5 znaków")]
        [Required(ErrorMessage = "Proszę wpisz wiadomość!")]
        public string Message { get; set; }

        public String Priority { get; set; } //String -> Priority Enum

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }


    }
}
