using System;
using System.Collections.Generic;

namespace MedicalCenterNetwork.Models
{
    // Класс для отображения элемента расписания
    public class ScheduleItem
    {
        public int ID_appointment { get; set; }
        public DateTime DateTime { get; set; }
        public string PatientFullName { get; set; }
        public string DoctorFullName { get; set; }
        public string ServiceName { get; set; }
        public string Status { get; set; }
        public string Cabinet { get; set; }
        public TimeSpan Duration { get; set; }
    }

    // Класс для отображения дня в расписании
    public class ScheduleDay
    {
        public DateTime Date { get; set; }
        public List<ScheduleItem> Appointments { get; set; } = new List<ScheduleItem>();

        public string DayOfWeekRus
        {
            get
            {
                switch (Date.DayOfWeek)
                {
                    case DayOfWeek.Monday: return "Понедельник";
                    case DayOfWeek.Tuesday: return "Вторник";
                    case DayOfWeek.Wednesday: return "Среда";
                    case DayOfWeek.Thursday: return "Четверг";
                    case DayOfWeek.Friday: return "Пятница";
                    case DayOfWeek.Saturday: return "Суббота";
                    case DayOfWeek.Sunday: return "Воскресенье";
                    default: return "";
                }
            }
        }
    }
}