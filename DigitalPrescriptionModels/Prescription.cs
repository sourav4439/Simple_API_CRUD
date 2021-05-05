
namespace DigitalPrescriptionModels
{
    public class Prescription
    {
        public int Id { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public string Date { get; set; }
        public Cc Cc { get; set; }
        public int CcId { get; set; }
        public Oh Oh { get; set; }
        public int OhId { get; set; }
        public Cf Cf { get; set; } 
        public int CfId { get; set; }
        public Advice Advice { get; set; }
        public int AdviceId { get; set; }
        public Medicine Medicine { get; set; }
        public int MedicineId { get; set; }

    }
}