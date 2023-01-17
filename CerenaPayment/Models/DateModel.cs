using System.ComponentModel.DataAnnotations;

namespace CerenaPayment.Models
{
    public class DateModel
    {
        [Required(ErrorMessage = "Selecione o dia")]
        public int Day { get; set; }

        [Required(ErrorMessage = "Selecione o mês")]
        public string Month { get; set; }

        [Required(ErrorMessage = "Selecione o ano")]
        public string Year { get; set; }
    }
}
