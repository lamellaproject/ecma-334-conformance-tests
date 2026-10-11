/*
Rules: E15-10-4-conversion-user-defined; E15-10-4-implicit-conversion-classification; E15-10-4-conversion-source-parameter; E15-10-4-conversion-target-return
Authority: ECMA-334 7th ed 15.10.4
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: implicit operator Token(Gauge x)
Into: explicit operator Token(Gauge x)
*/
using System;
class Token { public int N; public Token(int n) { N = n; } }
class Gauge
{
    public int N;
    public Gauge(int n) { N = n; }
    public static implicit operator Token(Gauge x) { Program.Calls++; return new Token(x.N + 6); }
}
class Program
{
    static int checks, failures;
    public static int Calls;
    static int Read(Token x) { return x.N; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge source = new Gauge(13);
        Token assigned = source;
        Check(assigned.N == 19, "implicit-assignment-target");
        Check(Read(source) == 19, "implicit-argument-target");
        Token cast = (Token)source;
        Check(cast.N == 19, "implicit-cast-target");
        Check(source.N == 13 && Calls == 3, "conversion-source-and-calls");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
