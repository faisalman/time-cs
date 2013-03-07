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
    const int ONE_SECOND = 1;
    const int ONE_MINUTE = 60 * ONE_SECOND;
    const int ONE_HOUR = 60 * ONE_MINUTE;
    const int ONE_DAY = 24 * ONE_HOUR;
    const int ONE_WEEK = 7 * ONE_DAY;
    const int ONE_MONTH = 30 * ONE_DAY;
    const int ONE_YEAR = 12 * ONE_MONTH;
				
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
      else if (secondsDiff < ONE_MINUTE)
      {
        value = (int) secondsDiff;
        unit = value > 1 ? "seconds" : "second";
      }
      else if (secondsDiff < ONE_HOUR)
      {
        value = (int) secondsDiff / ONE_MINUTE;
        unit = value > 1 ? "minutes" : "minute";
      }
      else if (secondsDiff < ONE_DAY)
      {
        value = (int) secondsDiff / ONE_HOUR;
        unit = value > 1 ? "hours" : "hour";
      }
      else if (secondsDiff < ONE_WEEK)
      {
        value = (int) secondsDiff / ONE_DAY;
        unit = value > 1 ? "days" : "day";
      }
      else if (secondsDiff < ONE_MONTH)
      {
        value = (int) secondsDiff / ONE_WEEK;
        unit = value > 1 ? "weeks" : "week";
      }
      else if (secondsDiff < ONE_YEAR)
      {
        value = (int) secondsDiff / ONE_MONTH;
        unit = value > 1 ? "months" : "month";
      }
      else
      {
        value = (int) secondsDiff / ONE_YEAR;
        unit = value > 1 ? "years" : "year";
      }
			
      return string.Join(" ", new[] { (isAgo ? "about" : "in about"), value.ToString(), unit, (isAgo ? "ago" : "") });
    }
  }
}
