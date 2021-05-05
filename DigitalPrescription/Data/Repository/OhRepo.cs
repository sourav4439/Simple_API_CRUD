using DigitalPrescriptionModels;
using DigitalPrescription.Data.Interfaces;

namespace DigitalPrescription.Data.Repository
{
    public class OhRepo:Repository<Oh>,IOhRepo
    {
        public OhRepo(AppDb Db):base(Db)
        {
            
        }
    }
}