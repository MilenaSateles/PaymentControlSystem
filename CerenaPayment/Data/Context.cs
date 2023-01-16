using CerenaPayment.Models;
using Microsoft.EntityFrameworkCore;

namespace CerenaPayment.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        
        //Mapeando no context:
        public DbSet<PatientModel> Patients { get; set; }
        public DbSet<TherapyModel> Therapies { get; set; }
    }
}
