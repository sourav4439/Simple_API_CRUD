using DigitalPrescriptionModels;
using Microsoft.EntityFrameworkCore;
namespace DigitalPrescription.Data
{
    public class AppDb:DbContext
       
    {
        public AppDb(DbContextOptions<AppDb> options):base(options)
        {
            
        }
        public DbSet<Cc> CCs { get; set; }
        public DbSet<Advice> Advices { get; set; }
        public DbSet<CategoryOfMedicine> CategoryOfMedicines { get; set; }
        public DbSet<Cf> Cfs { get; set; }
        public DbSet<MedCompany> MedCompanies { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Oh> Ohs { get; set; }
        public DbSet<Patient> Patients { get; set; }
        
        
     }
}