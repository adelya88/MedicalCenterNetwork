using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenterNetwork.Models
{
    public class CompletedProcedure
    {
        public int ID_procedure { get; set; }
        public int ID_branch { get; set; }
        public int ID_patient { get; set; }
        public int ID_nurse { get; set; }
        public string ProcedureName { get; set; }
        public DateTime ProcedureDateTime { get; set; }
        public int? ID_record { get; set; }

        // Навигационные свойства
        public Patient Patient { get; set; }
        public Employee Nurse { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public Branch Branch { get; set; }
    }
}
