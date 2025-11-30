using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenterNetwork.Models
{
    public static class UserSession
    {
        public static int EmployeeID { get; set; }
        public static string Login { get; set; }
        public static string FullName { get; set; }
        public static string Position { get; set; }
        public static int BranchID { get; set; }
        public static string BranchName { get; set; }

        public static void Clear()
        {
            EmployeeID = 0;
            Login = string.Empty;
            FullName = string.Empty;
            Position = string.Empty;
            BranchID = 0;
            BranchName = string.Empty;
        }
    }
}
