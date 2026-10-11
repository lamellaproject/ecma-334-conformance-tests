/*
Rules: E12-9-7-converted-value; E12-9-7-cast; E12-9-7-form; E12-9-1-form-cast
Authority: ECMA-334 7th ed 12.9.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: (int)Source()
Into: 0
*/
using System;
struct Token
{
    public int Value;
    public static explicit operator int(Token x) { Program.Trace += "C"; return x.Value + 4; }
}
class Program
{
    public static string Trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Token Source() { Trace += "E"; Token t = new Token(); t.Value = 3; return t; }
    static void Main()
    {
        int result = (int)Source();
        Check(result == 7, "conversion-result"); Check(Trace == "EC", "operand-once-before-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
