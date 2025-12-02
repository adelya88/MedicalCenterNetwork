using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenterNetwork.Models
{
    public class Patient
    {
        public int ID_patient { get; set; }
        public int ID_branch { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PassportSeriesNumber { get; set; }
        public string Address { get; set; }
        public DateTime RegistrationDate { get; set; }

        // Навигационные свойства
        public string FullName => $"{LastName} {FirstName} {MiddleName}";
        public int Age => DateTime.Now.Year - DateOfBirth.Year -
                         (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear ? 1 : 0);
        public Branch Branch { get; set; }
    }
}
