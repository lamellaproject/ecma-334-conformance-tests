/*
Rules: E12-8-7-1-type-static-property
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int result = Worker.Value;
Into: int result = 3;
*/
using System;
class Worker
{
    public static int calls;
    public static int Value { get { calls++; return 3; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int result = Worker.Value;
        Check(result == 3, "type-static-property-returns-accessor-value");
        Check(Worker.calls == 1, "type-static-property-executes-accessor-without-receiver");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
