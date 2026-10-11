/*
Rules: E13-6-2-1-for-local-scope
Authority: ECMA-334 7th ed 13.6.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int index = 0, limit = index + 3
Into: int index = 1, limit = index + 3
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int sum = 0;
        for (int index = 0, limit = index + 3; index < limit; index++) sum += index;
        Check(sum == 3, "for-local-in-initializer-condition-iterator-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
