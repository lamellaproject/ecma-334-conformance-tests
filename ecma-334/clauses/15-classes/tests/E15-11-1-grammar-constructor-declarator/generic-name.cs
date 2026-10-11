/*
Rules: E15-11-1-grammar-constructor-declarator; E15-11-1-constructor-class-name
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public Gauge(T value)
Into: private Gauge(T value)
*/
using System;
class Gauge<T> { public T Value; public Gauge(T value) { Value = value; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Gauge<int>(13).Value == 13, "generic-class-constructor-name");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
