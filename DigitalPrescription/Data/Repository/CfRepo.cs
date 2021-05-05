using DigitalPrescriptionModels;
using DigitalPrescription.Data.Interfaces;

namespace DigitalPrescription.Data.Repository
{
    public class CfRepo:Repository<Cf>,ICfRepo
    {
        public CfRepo(AppDb Db):base(Db)
        {
            
        }
    }
}