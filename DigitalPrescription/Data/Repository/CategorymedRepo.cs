using DigitalPrescriptionModels;
using DigitalPrescription.Data.Interfaces;

namespace DigitalPrescription.Data.Repository
{
    public class CategorymedRepo:Repository<CategoryOfMedicine>,ICategorymedRepo
    {
        public CategorymedRepo(AppDb Db):base(Db)
        {
            
        }
    }
}