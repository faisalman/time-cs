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

  	// As DateTime extension method
  	Console.WriteLine(d2.GetRelative(d1)); // output: "about 30 seconds ago"

  	// As usual static method
  	Console.WriteLine(Time.GetRelative(d2, d1)); // output: "about 30 seconds ago"

  	Console.ReadLine();
  }
}
```

## License

MIT License

Copyright © 2013 Faisalman <<fyzlman@gmail.com>>
