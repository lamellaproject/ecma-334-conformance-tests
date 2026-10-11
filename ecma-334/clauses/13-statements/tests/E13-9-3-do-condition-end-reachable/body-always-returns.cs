/*
Rules: E13-9-3-do-condition-end-reachable
Authority: ECMA-334 7th ed 13.9.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: return 3;
Into: break;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(bool flag) { do { return 3; } while (flag); }
    static void Main()
    {
        Check(Read(false) == 3, "unreachable-body-end-with-false-condition");
        Check(Read(true) == 3, "unreachable-body-end-with-true-condition");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
