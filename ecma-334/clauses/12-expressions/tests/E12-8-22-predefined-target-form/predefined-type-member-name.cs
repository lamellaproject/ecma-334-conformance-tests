/*
Rules: E12-8-22-predefined-target-form; E12-8-22-entity-form
Authority: ECMA-334 7th ed 12.8.22
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: nameof(int.CompareTo)
Into: nameof(int.Equals)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(nameof(int.CompareTo) == "CompareTo", "predefined-type-starts-named-entity");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
