using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenterNetwork.Models
{
    public class MedicalService
    {
        public int ID_service { get; set; }
        public string Name { get; set; }
        public int Duration_minutes { get; set; }
        public decimal Base_cost { get; set; }
    }
}
