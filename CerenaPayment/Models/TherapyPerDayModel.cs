using System.ComponentModel.DataAnnotations;

namespace CerenaPayment.Models
{
    public class TherapyPerDayModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Informe o horário da terapia.")]
        public string Time { get; set; }

        [Required(ErrorMessage = "Informe o nome completo do paciente.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a quantidade de sessões.")]
        public int Sessions { get; set; }

        [Required(ErrorMessage = "Informe o valor da sessão. ")]
        public decimal Value { get; set; }

        public string? Notes { get; set; } = default;

        //public void NoNotes(string notes)
        //{
        //    if (Notes != null)         
        //        Notes = notes;
        //    else
        //        Notes = default;
        //}
    }
}
