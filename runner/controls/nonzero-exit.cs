/*
Control: nonzero-exit
Purpose: Correct output with nonzero exit status must fail.
Version: 7.3
Expected: run
Stdout: OK 1
*/
using System;
class Program {
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Main() { Check(true, "exit"); if (failures == 0) Console.WriteLine("OK " + checks); return 7; }
}
