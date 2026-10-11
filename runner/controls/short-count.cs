/*
Control: short-count
Purpose: Fewer checks than the header pins must fail.
Version: 7.3
Expected: run
Stdout: OK 2
*/
using System;
class Program {
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { Check(true, "only-one"); if (failures == 0) Console.WriteLine("OK " + checks); }
}
