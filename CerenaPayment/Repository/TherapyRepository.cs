using CerenaPayment.Data;
using CerenaPayment.Models;

namespace CerenaPayment.Repository
{
    public class TherapyRepository : ITherapyRepository
    {
        private readonly Context _context;

        public TherapyRepository(Context context)
        {
            _context = context;
        }

        public TherapyModel Add(TherapyModel therapy)
        {
            _context.Therapies.Add(therapy);
            _context.SaveChanges();
            return therapy;
        }

        public bool Delete(int id)
        {
            TherapyModel therapyDB = ListById(id);

            if (therapyDB == null)
                throw new Exception("Não foi possível apagar a terapia :(");

            _context.Therapies.Remove(therapyDB);
            _context.SaveChanges();
            return true;
        }

        public TherapyModel ListById(int id)
        {
            return _context.Therapies.FirstOrDefault(x => x.Id == id)!;
        }

        public List<TherapyModel> SearchAll()
        {
            return _context.Therapies.ToList();
        }

        public TherapyModel Update(TherapyModel therapy)
        {
            TherapyModel therapyDB = ListById(therapy.Id);

            if (therapyDB == null)
                throw new Exception("Houve um erro na atualização da terapia :(");

            therapyDB.Nome = therapy.Nome;

            _context.Therapies.Update(therapyDB);
            _context.SaveChanges();
            return therapyDB;
        }
    }
}
