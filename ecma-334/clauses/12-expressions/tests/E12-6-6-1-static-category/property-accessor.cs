/*
Rules: E12-6-6-1-static-category; E12-6-6-1-static-invoke; E12-6-6-1-member-result
Authority: ECMA-334 7th ed 12.6.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Worker.Value
Into: Worker.Other
*/
using System;
class Worker
{
    public static int calls;
    public static int Value { get { calls++; return 3; } }
    public static int Other { get { calls++; return 8; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int result = Worker.Value;
        Check(Worker.calls == 1, "static-property-accessor-invoked-once");
        Check(result == 3, "static-property-returns-body-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
