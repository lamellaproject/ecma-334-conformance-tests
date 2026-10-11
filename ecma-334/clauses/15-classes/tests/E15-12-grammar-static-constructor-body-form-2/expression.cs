/*
Rules: E15-12-grammar-static-constructor-body-form-2; E15-12-static-constructor-expression-execution
Authority: ECMA-334 7th ed 15.12
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: => Initialize();
Into: => N = 14;
*/
using System;
class Gauge { public static int N; static Gauge() => Initialize(); static void Initialize() { N = 13; Program.Calls++; } }
class Program
{
    static int checks, failures;
    public static int Calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Gauge.N == 13, "static-constructor-expression-value");
        Check(Calls == 1, "static-constructor-expression-effect");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
