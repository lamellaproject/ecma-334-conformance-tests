/*
Control: failed-check
Purpose: Deliberately false Check must produce a failing result.
Version: 7.3
Expected: run
Stdout: OK 1
*/
using System;
class Program {
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { Check(false, "deliberate-failure"); if (failures == 0) Console.WriteLine("OK " + checks); }
}
