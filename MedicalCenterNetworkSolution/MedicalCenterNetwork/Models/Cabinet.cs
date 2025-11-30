using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenterNetwork.Models
{
    public class Cabinet
    {
        public int ID_cabinet { get; set; }
        public int ID_branch { get; set; }
        public string CabinetNumber { get; set; }
        public string Purpose { get; set; }

        // Навигационные свойства
        public Branch Branch { get; set; }
    }
}
