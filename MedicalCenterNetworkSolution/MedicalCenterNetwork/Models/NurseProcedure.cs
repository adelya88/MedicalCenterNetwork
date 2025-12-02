using System;

namespace MedicalCenterNetwork.Models
{
    public class NurseProcedure
    {
        public int ID_procedure { get; set; }
        public int ID_patient { get; set; }
        public string PatientFullName { get; set; }
        public int ID_nurse { get; set; }
        public string ProcedureType { get; set; } // Это будет ProcedureName из таблицы
        public DateTime ScheduledDateTime { get; set; } // Это будет ProcedureDateTime из таблицы
        public DateTime? CompletedDateTime { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public int? MedicalRecordID { get; set; }
        public string Diagnosis { get; set; }

        // Расчетное свойство
        public bool IsCompleted => CompletedDateTime.HasValue;
        public bool IsOverdue => !IsCompleted && ScheduledDateTime < DateTime.Now;
    }
}