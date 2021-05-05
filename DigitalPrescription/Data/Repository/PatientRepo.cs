using DigitalPrescriptionModels;
using DigitalPrescription.Data.Interfaces;

namespace DigitalPrescription.Data.Repository
{
    public class PatientRepo:Repository<Patient>,IPatientRepo
    {
        public PatientRepo(AppDb Db):base(Db)
        {
            
        }
    }
}