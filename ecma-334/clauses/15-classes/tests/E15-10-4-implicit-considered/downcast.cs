/*
Rules: E15-10-4-implicit-considered
Authority: ECMA-334 7th ed 15.10.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: implicit operator T(Gauge<T> x)
Into: explicit operator T(Gauge<T> x)
*/
using System;
class Gauge<T> where T : Gauge<T>, new()
{
    public int N;
    public static implicit operator T(Gauge<T> x) { Program.Calls++; T result = new T(); result.N = 31; return result; }
}
class Token : Gauge<Token> { public Token() { } }
class Program
{
    static int checks, failures;
    public static int Calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge<Token> source = new Gauge<Token>();
        // The implicit conversion remains available for assignment despite the predefined explicit downcast.
        Token result = source;
        Check(result.N == 31, "implicit-assignment-with-predefined-explicit-result");
        Check(Calls == 1 && !object.ReferenceEquals(source, result), "implicit-assignment-with-predefined-explicit-call");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
