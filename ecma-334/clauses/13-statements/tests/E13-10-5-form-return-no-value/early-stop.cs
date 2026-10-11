/*
Rules: E13-10-5-form-return-no-value; E13-10-1-form-return-jump; E13-10-5-no-value-members
Authority: ECMA-334 7th ed 13.10.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: if (stop) return;
Into: if (stop) { }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int visits;
    static void Visit(bool stop) { if (stop) return; visits++; }
    static void Main()
    {
        Visit(true);
        Check(visits == 0, "bare-return-stops-body");
        Visit(false);
        Check(visits == 1, "other-path-continues");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
