using DigitalPrescriptionModels;
using DigitalPrescription.Data.Interfaces;

namespace DigitalPrescription.Data.Repository
{
    public class CcRepo:Repository<Cc>,ICcRepo
    {
        public CcRepo(AppDb Db):base(Db)
        {
            
        }
    }
}