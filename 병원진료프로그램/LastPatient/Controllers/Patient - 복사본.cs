using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LastPatient.Controllers
{
    public class Patient
    {
        [Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Symptom { get; set; }
        public DateTime? Date { get; set; } = DateTime.Now;
        public DateTime? Birthdate { get; set; }
        public string? Discounts { get; set; }
        public int? Surgery { get; set; }
        public int? Medicine { get; set; }
        public int? MRI { get; set; }
        public int? CT { get; set; }
        public int? X_ray { get; set; }
        public int? InCnt { get; set; }
        public int? OutCnt { get; set; }
        public string? TreatmentDetails { get; set; }
        public DateTime? TreatmentDate { get; set; }
        public DateTime? ReservationDate { get; set; }
        public DateTime? HospitalizationDate { get; set; }
        public DateTime? DischargeDate { get; set; }
    }
    public class VisitPatients
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        public string? VisitName { get; set; }
        [Required]
        public string? VisitHp { get; set; }
        [Required]
        public string? VisitPatient { get; set; }
		[Required]
		public string? VisitOX { get; set; }
	}
}

