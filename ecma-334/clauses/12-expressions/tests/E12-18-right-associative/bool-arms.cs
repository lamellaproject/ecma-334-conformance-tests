/*
Rules: E12-18-right-associative
Authority: ECMA-334 7th ed 12.18
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: a ? b : c ? d : e
Into: (a ? b : c) ? d : e
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool a = true, b = false, c = true, d = false, e = true;
        bool result = a ? b : c ? d : e;
        Check(!result, "right-association-selects-b");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
