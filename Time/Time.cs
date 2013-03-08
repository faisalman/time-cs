// Time.cs
// Extended C# DateTime Library
// https://github.com/faisalman/time-cs
//
// MIT License
// Copyright © 2013 Faisalman <fyzlman@gmail.com>

using System;

namespace Faisalman.Utils
{
  public struct Age
  {
    public int Years;
    public int Months;
    public int Days;
    public Age(int years, int months, int days)
    {
      this.Years = years;
      this.Months = months;
      this.Days = days;
    }
    public override string ToString()
    {
      return this.Years.ToString() + " " + (this.Years > 1 ? "years" : "year")
        + " " + this.Months.ToString() + " " + (this.Months > 1 ? "months" : "month")
        + " " + this.Days.ToString() + " " + (this.Days > 1 ? "days": "day");
    }
  }

  public static class Time
  {
    const long SECOND_TICKS = TimeSpan.TicksPerSecond;
    const long MINUTE_TICKS = TimeSpan.TicksPerMinute;
    const long HOUR_TICKS = TimeSpan.TicksPerHour;
    const long DAY_TICKS = TimeSpan.TicksPerDay;
    const long WEEK_TICKS = TimeSpan.TicksPerDay * 7;
    const long MONTH_TICKS = TimeSpan.TicksPerDay * 30;
    const long YEAR_TICKS = TimeSpan.TicksPerDay * 365;

    public static Age GetAge(this DateTime bday, DateTime cday)
    {
      Age age = new Age();
      
      if ((cday.Year - bday.Year) > 0 ||
          (((cday.Year - bday.Year) == 0) && ((bday.Month < cday.Month) ||
            ((bday.Month == cday.Month) && (bday.Day <= cday.Day)))))
      {
        int daysInBdayMonth = DateTime.DaysInMonth(bday.Year, bday.Month);
        int daysRemain = cday.Day + (daysInBdayMonth - bday.Day);

        if (cday.Month > bday.Month)
        {
          age.Years = cday.Year - bday.Year;
          age.Months = cday.Month - (bday.Month + 1) + Math.Abs(daysRemain / daysInBdayMonth);
          age.Days = (daysRemain % daysInBdayMonth + daysInBdayMonth) % daysInBdayMonth;
        }
        else if (cday.Month == bday.Month)
        {
          if (cday.Day >= bday.Day)
          {
            age.Years = cday.Year - bday.Year;
            age.Months = 0;
            age.Days = cday.Day - bday.Day;
          }
          else
          {
            age.Years = (cday.Year - 1) - bday.Year;
            age.Months = 11;
            age.Days = DateTime.DaysInMonth(bday.Year, bday.Month) - (bday.Day - cday.Day);
          }
        }
        else
        {
          age.Years = (cday.Year - 1) - bday.Year;
          age.Months = cday.Month + (11 - bday.Month) + Math.Abs(daysRemain / daysInBdayMonth);
          age.Days = (daysRemain % daysInBdayMonth + daysInBdayMonth) % daysInBdayMonth;
        }
      }
      else
      {
        throw new ArgumentException("Birthday date must be earlier than current date");
      }
      return age;
    }
    				
    public static string GetRelativeTime(this DateTime currentTime, DateTime measuredTime)
    {
      bool isAgo = (currentTime.Ticks - measuredTime.Ticks) > 0;
      long secondsDiff = Math.Abs((currentTime.Ticks - measuredTime.Ticks) / SECOND_TICKS);
      string unit = "";
      long value = 0;

      if (secondsDiff == 0)
      {
        return "just now";
      }
      else if (secondsDiff < MINUTE_TICKS)
      {
        value = secondsDiff;
        unit = value > 1 ? "seconds" : "second";
      }
      else if (secondsDiff < HOUR_TICKS)
      {
        value = secondsDiff / MINUTE_TICKS;
        unit = value > 1 ? "minutes" : "minute";
      }
      else if (secondsDiff < DAY_TICKS)
      {
        value = secondsDiff / HOUR_TICKS;
        unit = value > 1 ? "hours" : "hour";
      }
      else if (secondsDiff < WEEK_TICKS)
      {
        value = secondsDiff / DAY_TICKS;
        unit = value > 1 ? "days" : "day";
      }
      else if (secondsDiff < MONTH_TICKS)
      {
        value = secondsDiff / WEEK_TICKS;
        unit = value > 1 ? "weeks" : "week";
      }
      else if (secondsDiff < YEAR_TICKS)
      {
        value = secondsDiff / MONTH_TICKS;
        unit = value > 1 ? "months" : "month";
      }
      else
      {
        value = secondsDiff / YEAR_TICKS;
        unit = value > 1 ? "years" : "year";
      }
			
      return string.Join(" ", new[] { (isAgo ? "about" : "in about"), value.ToString(), unit, (isAgo ? "ago" : "") });
    }
  }
}
