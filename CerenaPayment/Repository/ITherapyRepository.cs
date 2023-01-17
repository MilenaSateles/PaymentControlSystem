using CerenaPayment.Models;

namespace CerenaPayment.Repository
{
    public interface ITherapyRepository
    {
        TherapyPerDayModel ListById(int id);

        List<TherapyPerDayModel> SearchAll();

        TherapyPerDayModel Add(TherapyPerDayModel therapy);

        TherapyPerDayModel Update(TherapyPerDayModel therapy);

        bool Delete(int id);

        List<TherapyPerDayModel> ListByDate(int day, int month, int year);
    }
}
