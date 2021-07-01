using System;
using System.Globalization;
using Test.Application.Common.Interfaces;

namespace Test.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
        public string ToLongDateShamsi(DateTime dt)
        {
            PersianCalendar PC = new PersianCalendar();
            int intYear = PC.GetYear(dt);
            int intMonth = PC.GetMonth(dt);
            int intDayOfMonth = PC.GetDayOfMonth(dt);
            DayOfWeek enDayOfWeek = PC.GetDayOfWeek(dt);
            string strMonthName = GetMonthName(intMonth);
            string strDayName = GetDayName(enDayOfWeek);

            return $"{strDayName} {intDayOfMonth} {strMonthName} {intYear}";

        }

        public DateTime ToShamsiDateTime(DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return new DateTime(pc.GetYear(value), pc.GetMonth(value), pc.GetDayOfMonth(value), pc.GetHour(value), pc.GetMinute(value), pc.GetSecond(value));
        }

        private static string GetDayName(DayOfWeek enDayOfWeek)
        {
            string strDayName;
            switch (enDayOfWeek)
            {
                case DayOfWeek.Friday:
                    strDayName = "جمعه";
                    break;
                case DayOfWeek.Monday:
                    strDayName = "دوشنبه";
                    break;
                case DayOfWeek.Saturday:
                    strDayName = "شنبه";
                    break;
                case DayOfWeek.Sunday:
                    strDayName = "یکشنبه";
                    break;
                case DayOfWeek.Thursday:
                    strDayName = "پنجشنبه";
                    break;
                case DayOfWeek.Tuesday:
                    strDayName = "سه شنبه";
                    break;
                case DayOfWeek.Wednesday:
                    strDayName = "چهارشنبه";
                    break;
                default:
                    strDayName = "";
                    break;
            }

            return strDayName;
        }

        private static string GetMonthName(int intMonth)
        {
            string strMonthName;
            switch (intMonth)
            {
                case 1:
                    strMonthName = "فروردین";
                    break;
                case 2:
                    strMonthName = "اردیبهشت";
                    break;
                case 3:
                    strMonthName = "خرداد";
                    break;
                case 4:
                    strMonthName = "تیر";
                    break;
                case 5:
                    strMonthName = "مرداد";
                    break;
                case 6:
                    strMonthName = "شهریور";
                    break;
                case 7:
                    strMonthName = "مهر";
                    break;
                case 8:
                    strMonthName = "آبان";
                    break;
                case 9:
                    strMonthName = "آذر";
                    break;
                case 10:
                    strMonthName = "دی";
                    break;
                case 11:
                    strMonthName = "بهمن";
                    break;
                case 12:
                    strMonthName = "اسفند";
                    break;
                default:
                    strMonthName = "";
                    break;
            }

            return strMonthName;
        }

        public string NowName => Now.ToString("yyyyMMddHHmmss");
    }
}
