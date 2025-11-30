using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenterNetwork.Models
{
    public class MedicalRecord
    {
        public int ID_record { get; set; }
        public int ID_patient { get; set; }
        public int ID_appointment { get; set; }
        public int ID_doctor { get; set; }
        public string Complaints { get; set; }
        public string Diagnosis { get; set; }
        public string Anamnesis { get; set; }
        public string ExaminationResults { get; set; }
        public string Prescriptions { get; set; }
        public DateTime CreatedDateTime { get; set; }

        // Навигационные свойства
        public Patient Patient { get; set; }
        public Appointment Appointment { get; set; }
        public Employee Doctor { get; set; }
    }
}
