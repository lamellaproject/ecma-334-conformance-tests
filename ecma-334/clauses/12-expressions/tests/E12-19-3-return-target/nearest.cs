/*
Rules: E12-19-3-return-target
Authority: ECMA-334 7th ed 12.19.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: return;
Into: break;
*/
using System;
delegate void Invoke();
class Program
{
    static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Invoke outer = () =>
        {
            trace += "A";
            Invoke inner = () => { while (true) { trace += "B"; return; } trace += "X"; };
            inner();
            trace += "C";
        };
        outer();
        trace += "D";
        Check(trace == "ABCD", "inner-return-keeps-outer-and-member-continuations");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
