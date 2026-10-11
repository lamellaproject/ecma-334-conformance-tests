/*
Rules: E13-8-3-governing-unique-user-conversion; E13-8-3-switch-expression-evaluation; E13-8-3-switch-expression-conversion
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: switch (Make())
Into: switch ((object)Make())
*/
using System;
class Token
{
    public static implicit operator int(Token value) { Program.trace += "C"; return 7; }
}
class Program
{
    public static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Token Make() { trace += "E"; return new Token(); }
    static bool Guard() { trace += "G"; return true; }
    static void Main()
    {
        int selected = 0;
        switch (Make())
        {
            case 7 when Guard(): selected = 7; trace += "B"; break;
            default: selected = 9; trace += "D"; break;
        }
        trace += "X";
        Check(trace == "ECGBX", "evaluate-convert-guard-body-end-in-order-once");
        Check(selected == 7, "converted-governing-value-matches");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
