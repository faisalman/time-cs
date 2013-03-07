using System;
using Faisalman.Utils;

class Program
{
  static void Main(string[] args)
  {
  	DateTime d1 = DateTime.Now;
  	DateTime d2 = d1.AddSeconds(30);
    DateTime d3 = new DateTime(1970, 8, 21);
    DateTime d4 = new DateTime(2014, 4, 30);

  	// As DateTime extension method
    Console.WriteLine(d2.GetRelative(d1)); // output: "about 30 seconds ago"
  	// As usual static method
    Console.WriteLine(Time.GetRelative(d2, d1)); // output: "about 30 seconds ago"

    Console.WriteLine(Time.GetAge(d3, d4)); // output: "43 years 8 months 9 days"

  	Console.ReadLine();
  }
}