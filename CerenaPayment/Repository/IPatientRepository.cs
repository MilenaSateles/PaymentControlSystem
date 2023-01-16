using CerenaPayment.Models;

namespace CerenaPayment.Repository
{
    public interface IPatientRepository
    {
        PatientModel ListById(int id);

        List<PatientModel> SearchAll();

        PatientModel Add(PatientModel patient);

        PatientModel Update(PatientModel patient);

        bool Delete(int id);
    }
}
