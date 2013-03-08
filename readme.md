# Time.cs

Extended C# DateTime Library

## Example

```cs
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
    Console.WriteLine(d2.GetRelativeTime(d1)); // output: "about 30 seconds ago"
    Console.WriteLine(d1.GetRelativeTime(d2)); // output: "in about 30 seconds"
    // As usual static method
    Console.WriteLine(Time.GetRelativeTime(d2, d1)); // output: "about 30 seconds ago"
    Console.WriteLine(Time.GetRelativeTime(d1, d2)); // output: "in about 30 seconds"

    Console.WriteLine(Time.GetAge(d3, d4)); // output: "43 years 8 months 9 days";

    Console.ReadLine();
  }
}
```

## License

MIT License

Copyright © 2013 Faisalman <<fyzlman@gmail.com>>
