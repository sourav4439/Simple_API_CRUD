using DigitalPrescriptionModels;
using DigitalPrescription.Data.Interfaces;

namespace DigitalPrescription.Data.Repository
{
    public class MedCompanyRepo:Repository<MedCompany>,IMedCompanyRepo
    {
        public MedCompanyRepo(AppDb Db):base(Db)
        {
            
        }
    }
}