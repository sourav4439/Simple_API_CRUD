using DigitalPrescriptionModels;
using DigitalPrescription.Data.Interfaces;

namespace DigitalPrescription.Data.Repository
{
    public class AdviceRepo:Repository<Advice>,IAdviceRepo
    {
        public AdviceRepo(AppDb Db):base(Db)
        {
            
        }
    }
}