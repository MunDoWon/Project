using System.ComponentModel.DataAnnotations;

namespace LastPatient.Controllers
{
    public class Prescription
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime PrescriptionDate { get; set; }

        public string? MedicationName { get; set; }
        public string? Dosage { get; set; }
    }
}
