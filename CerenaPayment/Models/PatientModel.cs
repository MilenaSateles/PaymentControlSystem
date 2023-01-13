using System.ComponentModel.DataAnnotations;

namespace CerenaPayment.Models
{
    public class PatientModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome completo do paciente.")]
        public string Nome { get; set; }
    }
}
