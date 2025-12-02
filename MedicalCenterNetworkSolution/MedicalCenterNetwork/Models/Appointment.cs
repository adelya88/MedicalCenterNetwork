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

        // Вспомогательные поля для хранения данных из запросов
        private string _doctorFullName;
        private string _serviceName;

        public void SetDoctorFullName(string name) => _doctorFullName = name;
        public void SetServiceName(string name) => _serviceName = name;

        // Методы для получения данных
        public string GetDoctorFullName() => _doctorFullName ?? Employee?.FullName;
        public string GetServiceName() => _serviceName ?? MedicalService?.Name;
    }
}
