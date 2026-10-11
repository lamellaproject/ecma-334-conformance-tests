/*
Rules: E15-10-4-conversion-nullable-source-underlying; E15-10-4-conversion-nullable-target-underlying
Authority: ECMA-334 7th ed 15.10.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: operator Token?(Gauge? x) { Program.Calls++; return x.HasValue ? new Token(x.Value.N + 7) : (Token?)null; }
Into: operator Token?(Gauge? x) { Program.Calls++; return x.HasValue ? new Token(x.Value.N + 8) : (Token?)null; }
*/
using System;
struct Token { public int N; public Token(int n) { N = n; } }
struct Gauge { public int N; public Gauge(int n) { N = n; } public static explicit operator Token?(Gauge? x) { Program.Calls++; return x.HasValue ? new Token(x.Value.N + 7) : (Token?)null; } }
class Program
{
    static int checks, failures;
    public static int Calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge? present = new Gauge(13);
        Token? value = (Token?)present;
        Check(value.HasValue && value.Value.N == 20, "both-nullable-present");
        Gauge? absent = null;
        Token? missing = (Token?)absent;
        Check(!missing.HasValue && Calls == 2, "both-nullable-null-invokes-declared-operator");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
