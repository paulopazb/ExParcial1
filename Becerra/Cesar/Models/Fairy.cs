using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cesar.Models
{
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