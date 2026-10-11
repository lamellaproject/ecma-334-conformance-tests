/*
Rules: E12-8-1-object-creation-form
Authority: ECMA-334 7th ed 12.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: new Worker(3)
Into: new Worker(8)
*/
using System;
class Worker { public int value; public Worker(int value) { this.value = value; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Worker result = new Worker(3);
        Check(result.value == 3, "object-creation-is-primary-expression");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
