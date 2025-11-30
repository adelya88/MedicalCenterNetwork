using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenterNetwork.Models
{
    public class Employee
    {
        public int ID_employee { get; set; }
        public int ID_branch { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public int? ID_specialization { get; set; }
        public string Position { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } = true;

        public string SpecializationName { get; set; }
        public string BranchName { get; set; }
        public string Status { get; set; }

        // Навигационные свойства (для удобства)
        public string FullName => $"{LastName} {FirstName} {MiddleName}";
        public Branch Branch { get; set; }
        public Specialization Specialization { get; set; }
    }
}
