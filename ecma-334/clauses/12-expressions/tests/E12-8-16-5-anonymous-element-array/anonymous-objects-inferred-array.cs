/*
Rules: E12-8-16-5-anonymous-element-array; E12-8-16-1-anonymous-object-form; E12-8-16-5-implicit-type-initializer-form
Authority: ECMA-334 7th ed 12.8.16.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new { Code = 19, Active = false }
Into: new { Code = 7, Active = true }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var entries = new[] { new { Code = 7, Active = true }, new { Code = 19, Active = false } };
        Check(entries.Length == 2 && entries[0].Code == 7 && entries[0].Active, "first-anonymous-element");
        Check(entries[1].Code == 19 && !entries[1].Active, "second-anonymous-element");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
