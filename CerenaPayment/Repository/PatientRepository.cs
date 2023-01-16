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

        public List<PatientModel> SearchAll()
        {
            return _context.Patients.ToList();
        }

        public bool Delete(int id)
        {
            PatientModel patientDB = ListById(id);

            if (patientDB == null)
                throw new Exception("Não foi possível apagar o paciente :(");

            _context.Patients.Remove(patientDB);
            _context.SaveChanges();
            return true;
        }

        public PatientModel ListById(int id)
        {
            return _context.Patients.FirstOrDefault(x => x.Id == id)!;
        }

        public PatientModel Update(PatientModel patient)
        {
            PatientModel patientDB = ListById(patient.Id);

            if (patientDB == null)
                throw new Exception("Houve um erro na atualização do contato :(");

            patientDB.Nome = patient.Nome;
          
            _context.Patients.Update(patientDB);
            _context.SaveChanges();
            return patientDB;
        }
    }
}
