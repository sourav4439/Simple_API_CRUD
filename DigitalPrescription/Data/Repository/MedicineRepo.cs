using DigitalPrescriptionModels;
using DigitalPrescription.Data.Interfaces;

namespace DigitalPrescription.Data.Repository
{
    public class MedicineRepo:Repository<Medicine>,IMedicineRepo
    {
        public MedicineRepo(AppDb Db):base(Db)
        {
            
        }
    }
}