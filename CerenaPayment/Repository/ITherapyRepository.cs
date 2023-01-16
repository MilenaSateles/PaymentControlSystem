using CerenaPayment.Models;

namespace CerenaPayment.Repository
{
    public interface ITherapyRepository
    {
        TherapyModel ListById(int id);

        List<TherapyModel> SearchAll();

        TherapyModel Add(TherapyModel therapy);

        TherapyModel Update(TherapyModel therapy);

        bool Delete(int id);
    }
}
