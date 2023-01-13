using CerenaPayment.Models;

namespace CerenaPayment.Repository
{
    public interface IPatientRepository
    {
        PatientModel ListarPorId(int id);

        List<PatientModel> BuscarTodos();

        PatientModel Add (PatientModel contato);

        //PatientModel Atualizar(PatientModel contato);

        //bool Apagar(int id);
    }
}
