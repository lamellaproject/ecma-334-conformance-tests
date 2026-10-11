/*
Rules: E12-2-1-null-conversion
Authority: ECMA-334 7th ed 12.2.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int? number = null;
Into: int number = null;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string text = null;
        int? number = null;
        Check(text == null, "reference-null");
        Check(number == null, "nullable-null");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
