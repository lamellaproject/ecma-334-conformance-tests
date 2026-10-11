/*
Rules: E12-8-7-1-class-field-null
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Worker receiver = null;
Into: Worker receiver = new Worker();
*/
using System;
class Worker { public int value = 3; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Worker receiver = null;
        bool caught = false;
        try { int result = receiver.value; }
        catch (NullReferenceException) { caught = true; }
        catch (Exception) { }
        Check(caught, "null-class-instance-field-read-throws-null-reference-exception");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
