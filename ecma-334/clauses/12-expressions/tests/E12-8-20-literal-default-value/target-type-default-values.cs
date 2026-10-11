/*
Rules: E12-8-20-literal-default-value; E12-8-20-literal-default-form; E12-8-20-literal-syntax; E12-8-20-literal-conversion
Authority: ECMA-334 7th ed 12.8.20
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: int number = default;
Into: int number = 9;
*/
using System;
enum Mode { Active = 7 }
struct State { public int Number; public object Link; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int number = default;
        string text = default;
        Mode mode = default;
        State state = default;
        int? nullable = default;
        Check(number == 0, "default-literal-integral-target");
        Check(text == null, "default-literal-reference-target");
        Check(mode == (Mode)0, "default-literal-enum-without-zero-member");
        Check(state.Number == 0 && state.Link == null, "default-literal-struct-target");
        Check(!nullable.HasValue, "default-literal-nullable-target");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
