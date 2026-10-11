/*
Rules: E12-8-1-null-member-form
Authority: ECMA-334 7th ed 12.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: worker?.value
Into: worker.value
*/
using System;
class Worker { public int value = 3; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Worker worker = null;
        int? result = worker?.value;
        Check(result == null, "null-conditional-member-is-primary-expression");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
