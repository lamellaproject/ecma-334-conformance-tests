/*
Rules: E15-10-4-conversion-signature-target
Authority: ECMA-334 7th ed 15.10.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: operator DerivedToken(Gauge x)
Into: operator Token(Gauge x)
*/
using System;
class Token { public int N; public Token(int n) { N = n; } }
class DerivedToken : Token { public DerivedToken(int n) : base(n) { } }
class Gauge
{
    public static implicit operator Token(Gauge x) { return new DerivedToken(13); }
    public static implicit operator DerivedToken(Gauge x) { return new DerivedToken(19); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge source = new Gauge();
        Token first = source;
        DerivedToken second = source;
        Check(first.N == 13, "conversion-base-target-signature");
        Check(second.N == 19, "conversion-derived-target-signature");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
