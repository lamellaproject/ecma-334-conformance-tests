/*
Rules: E12-2-1-explicit-variable-type; E12-2-1-default-explicit-variable
Authority: ECMA-334 7th ed 12.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: object value = 31;
Into: int value = 31;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Choose(object value) { return 1; }
    static int Choose(int value) { return 2; }
    static void Main()
    {
        object value = 31;
        Check(Choose(value) == 1, "declared-variable-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
