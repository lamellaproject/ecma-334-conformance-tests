/*
Rules: E15-10-4-conversion-parameters-unique
Authority: ECMA-334 7th ed 15.10.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: operator Gauge<T, U>(U x)
Into: operator Gauge<T, U>(T x)
*/
using System;
class Gauge<T, U>
{
    public int N;
    public Gauge(int n) { N = n; }
    public static implicit operator Gauge<T, U>(T x) { return new Gauge<T, U>(13); }
    public static implicit operator Gauge<T, U>(U x) { return new Gauge<T, U>(19); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge<int, string> first = 3;
        Gauge<int, string> second = "coil";
        Check(first.N == 13, "first-type-parameter-signature");
        Check(second.N == 19, "second-type-parameter-signature");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
