/*
Rules: E15-10-4-predefined-implicit; E15-10-4-generic-collision
Authority: ECMA-334 7th ed 15.10.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: object result = source;
Into: object result = (int)other;
*/
using System;
class Gauge<T> { public T Value; public Gauge(T value) { Value = value; } public static implicit operator T(Gauge<T> x) { Program.Calls++; return x.Value; } }
class Program
{
    static int checks, failures;
    public static int Calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge<object> source = new Gauge<object>("payload");
        Gauge<int> other = new Gauge<int>(19);
        object result = source;
        Check(object.ReferenceEquals(result, source), "predefined-implicit-identity");
        Check(Calls == 0, "predefined-implicit-no-operator-call");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
