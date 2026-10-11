/*
Rules: E12-6-1-category-finalizers
Authority: ECMA-334 7th ed 12.6.1
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: ~Box()
Into: ~Other()
*/
using System;
class Box { ~Box() { } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box receiver = new Box();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
