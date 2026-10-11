/*
Rules: E15-10-2-unary-instance-type-symbol
Authority: ECMA-334 7th ed 15.10.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: operator +(Gauge<T> x)
Into: operator -(Gauge<T> x)
*/
using System;
class Gauge<T> { public T Value; public Gauge(T value) { Value = value; } public static T operator +(Gauge<T> x) { return x.Value; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(+new Gauge<int>(17) == 17, "generic-instance-integer");
        Check(+new Gauge<string>("lamp") == "lamp", "generic-instance-string");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
