/*
Rules: E12-8-22-definite-assignment-ignore
Authority: ECMA-334 7th ed 12.8.22
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: nameof(count)
Into: count.ToString()
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int count;
        string name = nameof(count);
        Check(name == "count", "name-of-unassigned-local");
        count = 7;
        Check(count == 7, "local-assigned-after-nameof");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
