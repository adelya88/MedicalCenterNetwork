using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenterNetwork.Models
{
    public class Appointment
    {
        public int ID_appointment { get; set; }
        public int ID_branch { get; set; }
        public int ID_patient { get; set; }
        public int ID_employee { get; set; }
        public int ID_service { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; }
        public decimal? Actual_cost { get; set; }
        public int? ID_cabinet { get; set; }

        // Навигационные свойства
        public Patient Patient { get; set; }
        public Employee Employee { get; set; }
        public MedicalService MedicalService { get; set; }
        public Cabinet Cabinet { get; set; }
        public Branch Branch { get; set; }

        public string PatientFullName => Patient?.FullName;
        public string DoctorFullName => Employee?.FullName;
        public string ServiceName => MedicalService?.Name;
    }
}
