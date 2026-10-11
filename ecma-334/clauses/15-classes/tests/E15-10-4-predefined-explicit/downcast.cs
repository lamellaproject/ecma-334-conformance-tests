/*
Rules: E15-10-4-predefined-explicit; E15-10-4-generic-collision
Authority: ECMA-334 7th ed 15.10.4
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: (Token)plain
Into: (Token)source
*/
using System;
class Gauge<T> where T : Gauge<T>, new()
{
    public int N;
    public static explicit operator T(Gauge<T> x) { Program.Calls++; T result = new T(); result.N = 31; return result; }
}
class Token : Gauge<Token> { public Token() { } }
class Program
{
    static int checks, failures;
    public static int Calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Token original = new Token();
        Gauge<Token> source = original;
        Token result = (Token)source;
        Check(object.ReferenceEquals(result, original), "predefined-explicit-identity");
        Check(Calls == 0, "predefined-explicit-no-operator-call");
        Gauge<Token> plain = new Gauge<Token>();
        bool invalid = false;
        try { Token unused = (Token)plain; }
        catch (InvalidCastException) { invalid = true; }
        catch (Exception) { }
        Check(invalid, "predefined-explicit-invalid-cast-type");
        Check(Calls == 0, "predefined-explicit-failure-no-operator-call");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
