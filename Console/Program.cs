using System;
using Faisalman.Utils;

class Program
{
  static void Main(string[] args)
  {
  	DateTime d1 = DateTime.Now;
  	DateTime d2 = d1.AddSeconds(30);

  	// As DateTime extension method
  	Console.WriteLine(d2.GetRelative(d1));

  	// As usual static method
  	Console.WriteLine(Time.GetRelative(d2, d1));

  	Console.ReadLine();
  }
}