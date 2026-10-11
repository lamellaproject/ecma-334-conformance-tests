/*
Rules: E15-9-2-property-static-permitted
Authority: ECMA-334 7th ed 15.9.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public static int Count
Into: public int Count
*/
using System;
class Box { public static int Count { get; set; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box.Count = 23;
        Check(Box.Count == 23, "static-property-access");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
