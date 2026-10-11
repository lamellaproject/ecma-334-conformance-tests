/*
Rules: E12-6-2-1-out-mode; E12-6-2-1-grammar-out; E12-6-2-1-out-assigned
Authority: ECMA-334 7th ed 12.6.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: out int value
Into: ref int value
*/
using System;
class Program
{
    static int checks, failures;
    static void Read(out int value) { value = 31; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int result; Read(out result);
        Check(result == 31, "output-definitely-assigned-after-call");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
