/*
Rules: E15-2-7-partial-single-part
Authority: ECMA-334 7th ed 15.2.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: partial class Solo
Into: partial partial class Solo
*/
using System;
partial class Solo { public int Read() { return 73; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Solo().Read() == 73, "sole-partial-declaration");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
