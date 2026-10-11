/*
Rules: E15-10-3-binary-instance-type-symbol
Authority: ECMA-334 7th ed 15.10.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: operator *(Gauge<T> x, int n)
Into: operator /(Gauge<T> x, int n)
*/
using System;
class Gauge<T> { public T Value; public Gauge(T value) { Value = value; } public static T operator *(Gauge<T> x, int n) { return x.Value; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Gauge<int>(17) * 3 == 17, "generic-binary-integer");
        Check(new Gauge<string>("coil") * 4 == "coil", "generic-binary-string");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
