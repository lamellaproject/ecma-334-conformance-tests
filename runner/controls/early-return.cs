/*
Control: early-return
Purpose: Returning before the final line must fail.
Version: 7.3
Expected: run
Stdout: OK 1
*/
using System;
class Program {
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { Check(true, "early"); return; }
}
