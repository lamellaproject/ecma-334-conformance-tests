/*
Rules: E12-8-16-7-null-projection-form; E12-8-16-7-projection-name; E12-8-16-7-projection-value
Authority: ECMA-334 7th ed 12.8.16.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new { empty?.Number }
Into: new { Number = (int?)19 }
*/
using System;
class Receiver { public int Number; }
class Program
{
    static int Choose(int? value) { return 1; }
    static int Choose(object value) { return 2; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Receiver empty = null;
        var value = new { empty?.Number };
        Check(value.Number == null, "null-projection-name-and-null-value");
        Check(Choose(value.Number) == 1, "null-projection-property-is-nullable");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
