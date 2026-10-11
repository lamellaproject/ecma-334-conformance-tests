/*
Rules: E12-8-22-invocation-priority
Authority: ECMA-334 7th ed 12.8.22
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: static int nameof = 0;
Into: static string nameof(int value) { return "invoked"; }
*/
using System;
class Program
{
    static int checks, failures;
    static int nameof = 0;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int count = 7;
        // Invoked member lookup removes this non-invocable field.
        string name = nameof(count);
        Check(name == "count", "noninvocable-field-allows-nameof");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
