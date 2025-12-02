using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenterNetwork.Models
{
    public static class CabinetExtensions
    {
        public static string GetBranchInfo(this Cabinet cabinet)
        {
            return cabinet.Branch?.Name ?? "Неизвестный филиал";
        }

        public static string GetFullInfo(this Cabinet cabinet)
        {
            return $"Кабинет {cabinet.CabinetNumber} - {cabinet.Purpose}";
        }
    }
}
