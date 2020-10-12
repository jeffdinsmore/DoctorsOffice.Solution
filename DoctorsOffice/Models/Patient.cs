using System.Collections.Generic;

namespace DoctorsOffice.Models
{
  public class Patient
  {
    public int PatientId { get; set; }
    public string PatientName { get; set; }
    public string Birthdate { get; set; }
    public int DoctorId { get; set; }
    public virtual Doctor Doctor { get; set; }
  }
}