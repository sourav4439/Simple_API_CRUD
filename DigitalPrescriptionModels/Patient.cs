using System.IO;
namespace DigitalPrescriptionModels
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public int GenderId { get; set; }
        public string Mobile { get; set; }

    }

    public enum Gender
    { 
        
        Male,
        Female
    }
}