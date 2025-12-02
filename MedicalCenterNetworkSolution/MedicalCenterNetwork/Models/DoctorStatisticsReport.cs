using System;

namespace MedicalCenterNetwork.Models
{
    public class DoctorStatisticsReport
    {
        // Общая информация за период
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }

        // Основная статистика
        public int TotalAppointments { get; set; }           // Всего приемов
        public int CompletedAppointments { get; set; }       // Завершено
        public int PlannedAppointments { get; set; }         // Запланировано
        public int CanceledAppointments { get; set; }        // Отменено
        public int NoShowAppointments { get; set; }          // Пациент не явился

        // Статистика по услугам
        public int UniquePatientsCount { get; set; }         // Уникальных пациентов
        public int MedicalRecordsCreated { get; set; }       // Записей в медкартах создано

        // Расчетные поля (можно вычислять на клиенте или в БД)
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

        // Средние показатели
        public double AverageAppointmentsPerDay
        {
            get
            {
                var days = (PeriodEnd - PeriodStart).TotalDays + 1;
                if (days <= 0) return 0;
                return Math.Round(TotalAppointments / days, 1);
            }
        }

        // Конструктор
        public DoctorStatisticsReport()
        {
            PeriodStart = DateTime.Today.AddDays(-30); // По умолчанию за последние 30 дней
            PeriodEnd = DateTime.Today;
        }
    }
}