/*
Rules: E9-2-9-declaration-in-for
Authority: ECMA-334 7th ed 9.2.9
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int cell = 3
Into: int cell = 0
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int sum = 0;
        for (int cell = 3; cell < 6; cell++) sum += cell;
        Check(sum == 12, "local-in-for-initializer");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
