using CerenaPayment.Data;
using CerenaPayment.Models;

namespace CerenaPayment.Repository
{
    public class PatientRepository : IPatientRepository
    {
        //Injeção de dependência por construtor
        private readonly Context _context;

        public PatientRepository(Context context)
        {
            _context = context;
        }

        public PatientModel Add(PatientModel patient)
        {
            //Gravação no banco de dados
            _context.Patients.Add(patient);
            _context.SaveChanges();
            return patient; 
        }

        public List<PatientModel> BuscarTodos()
        {
            return _context.Patients.ToList();
        }

        public PatientModel ListarPorId(int id)
        {
            return _context.Patients.FirstOrDefault(x => x.Id == id)!;
        }
    }
}
