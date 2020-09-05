using System;

namespace Utils.ClassExtensions
{
    public static class DateTimeExtension
    {
        public static DateTime StartOfMonth(this DateTime dateTime){
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        } 

        public static DateTime EndOfMonth(this DateTime dateTime){
            return dateTime.AddMonths(1).AddDays(-1);
        } 
    }
}