using System;

namespace MedicalCenterNetwork.Models
{
    public class BranchStatisticsReport
    {
        // Общая информация
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public int BranchID { get; set; }
        public string BranchName { get; set; }

        // Статистика по врачам
        public int TotalDoctors { get; set; }
        public int ActiveDoctors { get; set; }

        // Статистика по пациентам
        public int TotalPatients { get; set; }
        public int NewPatientsThisPeriod { get; set; }

        // Статистика по приемам
        public int TotalAppointments { get; set; }
        public int CompletedAppointments { get; set; }
        public int PlannedAppointments { get; set; }
        public int CanceledAppointments { get; set; }
        public int NoShowAppointments { get; set; }

        // Статистика по услугам
        public decimal TotalRevenue { get; set; }
        public decimal AverageAppointmentCost { get; set; }

        // Статистика по медсестрам
        public int TotalNurses { get; set; }
        public int CompletedProcedures { get; set; }

        // Расчетные поля
        public double CompletionRate
        {
            get
            {
                if (TotalAppointments == 0) return 0;
                return Math.Round((double)CompletedAppointments / TotalAppointments * 100, 2);
            }
        }

        public double NoShowRate
        {
            get
            {
                if (TotalAppointments == 0) return 0;
                return Math.Round((double)NoShowAppointments / TotalAppointments * 100, 2);
            }
        }

        public double AverageAppointmentsPerDoctor
        {
            get
            {
                if (ActiveDoctors == 0) return 0;
                return Math.Round((double)TotalAppointments / ActiveDoctors, 1);
            }
        }

        public double AverageRevenuePerDoctor
        {
            get
            {
                if (ActiveDoctors == 0) return 0;
                return Math.Round((double)TotalRevenue / ActiveDoctors, 2);
            }
        }

        // Конструктор
        public BranchStatisticsReport()
        {
            PeriodStart = DateTime.Today.AddDays(-30);
            PeriodEnd = DateTime.Today;
            BranchID = UserSession.BranchID;
        }
    }
}