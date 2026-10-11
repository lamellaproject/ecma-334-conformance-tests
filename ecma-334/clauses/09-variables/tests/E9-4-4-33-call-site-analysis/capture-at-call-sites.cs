/*
Rules: E9-4-4-33-call-site-analysis; E9-4-4-33-parent-context-analysis; E9-4-4-33-local-function-control-paths; E9-4-4-33-captured-call-entry
Authority: ECMA-334 7th ed 9.4.4.33
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: cell = 21;
Into: ;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int cell;
        int Read() { return cell; }
        cell = 21;
        Check(Read() == 21, "local-function-defined-before-assignment-called-after");
        cell = 39;
        Check(Read() == 39, "separate-call-site-and-current-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
