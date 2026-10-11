/*
Rules: E15-2-2-1-grammar-class-modifier-form-9
Authority: ECMA-334 7th ed 15.2.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: unsafe class Gauge
Into: class Gauge
*/
using System;
unsafe class Gauge
{
    public static int Read() { int value = 107; int* address = &value; return *address; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Gauge.Read() == 107, "unsafe-class-context");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
