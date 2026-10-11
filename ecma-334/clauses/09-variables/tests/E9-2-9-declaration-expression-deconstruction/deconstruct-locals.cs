/*
Rules: E9-2-9-declaration-expression-deconstruction
Authority: ECMA-334 7th ed 9.2.9
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: (int left, int right) = (16, 29);
Into: (int left, int right) = (29, 16);
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        (int left, int right) = (16, 29);
        Check(left == 16, "first-declaration-expression");
        Check(right == 29, "second-declaration-expression");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
