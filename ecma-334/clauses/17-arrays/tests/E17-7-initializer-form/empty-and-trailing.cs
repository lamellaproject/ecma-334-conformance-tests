/*
Rules: E17-7-initializer-form; E17-7-trailing-comma-form
Authority: ECMA-334 7th ed 17.7
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: int[] empty = { }
Into: int[] empty = { 1 }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] empty = { };
        int[] trailing = { 5, 12, };
        Check(empty.Length == 0, "optional-list-absent");
        Check(trailing.Length == 2, "trailing-comma-not-element");
        Check(trailing[0] == 5 && trailing[1] == 12, "trailing-comma-values");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
