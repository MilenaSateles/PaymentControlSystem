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

        public TherapyPerDayModel Add(TherapyPerDayModel therapy)
        {
            _context.Therapies.Add(therapy);
            _context.SaveChanges();
            return therapy;
        }

        public bool Delete(int id)
        {
            TherapyPerDayModel therapyDB = ListById(id);

            if (therapyDB == null)
                throw new Exception("Não foi possível apagar a terapia :(");

            _context.Therapies.Remove(therapyDB);
            _context.SaveChanges();
            return true;
        }

        public TherapyPerDayModel ListById(int id)
        {
            return _context.Therapies.FirstOrDefault(x => x.Id == id)!;
        }

        public List<TherapyPerDayModel> SearchAll()
        {
            return _context.Therapies.ToList();
        }

        public TherapyPerDayModel Update(TherapyPerDayModel therapy)
        {
            TherapyPerDayModel therapyDB = ListById(therapy.Id);

            if (therapyDB == null)
                throw new Exception("Houve um erro na atualização da terapia :(");

            therapyDB.Nome = therapy.Nome;

            _context.Therapies.Update(therapyDB);
            _context.SaveChanges();
            return therapyDB;
        }

        public List<TherapyPerDayModel> ListByDate(int day, int month, int year )
        {
            return _context.Therapies.Where(x => x.Date == new DateTime(day, month, year)).ToList();
        }
    }
}
