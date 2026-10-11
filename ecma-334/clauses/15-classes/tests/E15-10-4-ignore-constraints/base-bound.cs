/*
Rules: E15-10-4-ignore-constraints; E15-10-4-conversion-parameters-ignore-constraints; E15-10-4-conversion-parameters-unrelated
Authority: ECMA-334 7th ed 15.10.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: operator T(Gauge<T> x)
Into: operator Basis(Gauge<T> x)
*/
using System;
class Basis { public int N; }
class Token : Basis { public Token() { } }
class Gauge<T> : Basis where T : Basis, new()
{
    public static explicit operator T(Gauge<T> x) { Program.Calls++; T value = new T(); value.N = 31; return value; }
}
class Program
{
    static int checks, failures;
    public static int Calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge<Token> source = new Gauge<Token>();
        Token result = (Token)source;
        Check(result.N == 31 && Calls == 1, "constraint-does-not-substitute-base-endpoint");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
