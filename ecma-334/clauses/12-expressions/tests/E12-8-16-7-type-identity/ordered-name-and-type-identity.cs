/*
Rules: E12-8-16-7-type-identity
Authority: ECMA-334 7th ed 12.8.16.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new { Number = 19, Label = "spruce" }
Into: new { Number = 19L, Label = "spruce" }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var first = new { Number = 7, Label = "cedar" };
        var second = new { Number = 19, Label = "spruce" };
        first = second;
        Check(first.Number == 19 && first.Label == "spruce", "same-ordered-properties-assignable");
        Check(object.ReferenceEquals(first, second), "same-type-assignment-retains-reference");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
