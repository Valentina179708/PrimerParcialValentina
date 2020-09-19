using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EvalValentinaGemio.Models
{
    public class Paises
    {
        [Key]
        public int GemioID { get; set; }
        [Required(ErrorMessage = "Ingrese el nombre"), MaxLength(30)]
        [Display(Name = " Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese el nombre"), MaxLength(30)]
        [Display(Name = "Capital")]
        public string Capital { get; set; }
        [Required]
        public int Population { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0: hh.mm.ss}")]
        public DateTime timezones { get; set; }





    }
}