// Time.cs
// Extended C# DateTime Library
// https://github.com/faisalman/time-cs
//
// MIT License
// Copyright © 2013 Faisalman <fyzlman@gmail.com>

using System;

namespace Faisalman.Utils
{
  public static class Time
  {
    const int oneSecond = 1;
    const int oneMinute = 60 * oneSecond;
    const int oneHour = 60 * oneMinute;
    const int oneDay = 24 * oneHour;
    const int oneWeek = 7 * oneDay;
    const int oneMonth = 30 * oneDay;
    const int oneYear = 12 * oneMonth;
				
    public static string GetRelative(this DateTime currentTime, DateTime measuredTime)
    {
      bool isAgo = (currentTime.Ticks - measuredTime.Ticks) > 0;
      long secondsDiff = Math.Abs((currentTime.Ticks - measuredTime.Ticks) / 10000000);
      string unit = "";
      int value = 0;

      if (secondsDiff == 0)
      {
        return "just now";
      }
      else if (secondsDiff < oneMinute)
      {
        value = (int) secondsDiff;
        unit = value > 1 ? "seconds" : "second";
      }
      else if (secondsDiff < oneHour)
      {
        value = (int) secondsDiff / oneMinute;
        unit = value > 1 ? "minutes" : "minute";
      }
      else if (secondsDiff < oneDay)
      {
        value = (int) secondsDiff / oneHour;
        unit = value > 1 ? "hours" : "hour";
      }
      else if (secondsDiff < oneWeek)
      {
        value = (int) secondsDiff / oneDay;
        unit = value > 1 ? "days" : "day";
      }
      else if (secondsDiff < oneMonth)
      {
        value = (int) secondsDiff / oneWeek;
        unit = value > 1 ? "weeks" : "week";
      }
      else if (secondsDiff < oneYear)
      {
        value = (int) secondsDiff / oneMonth;
        unit = value > 1 ? "months" : "month";
      }
      else
      {
        value = (int) secondsDiff / oneYear;
        unit = value > 1 ? "years" : "year";
      }
			
      return string.Join(" ", new[] { (isAgo ? "about" : "in about"), value.ToString(), unit, (isAgo ? "ago" : "") });
    }
  }
}
