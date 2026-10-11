/*
Rules: E7-7-1-for-local-scope
Authority: ECMA-334 7th ed 7.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int value = 1
Into: int renamed = 1
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int sum = 0;
        for (int value = 1, limit = value + 3; value < limit; value++) { sum += value; }
        Check(sum == 6, "for-local-in-initializer-condition-iterator-and-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
