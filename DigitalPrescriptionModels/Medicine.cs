namespace DigitalPrescriptionModels
{
    public class Medicine
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public MedCompany Company { get; set; }
        public int CompanyId { get; set; }
        public CategoryOfMedicine CteMedicine { get; set; }
        public int CategoryId { get; set; }

    }
}