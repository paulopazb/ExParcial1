

namespace Cesar.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Fairy
    { 
        public enum TypeWishes
        {
            Pelicula,
            Peluche,
            Paraguas,
        }
        [Key]
        public int FairyID { get; set; }
        [Required]
        [Display(Name = "Nombre Completo")]
        [MinLength(2)]
        [MaxLength(24)]
        public string NickName { get; set; }
        [Required]
        public  TypeWishes Wishes { get; set; }
        [RegularExpression(@"^\w+([-+.']\w+)@\w+([-.]\w+)\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }
        [Display(Name = "Cumpleaños")]
        [DataType(DataType.Date)]
        public DateTime?  Birthdate { get; set; }



    }
}