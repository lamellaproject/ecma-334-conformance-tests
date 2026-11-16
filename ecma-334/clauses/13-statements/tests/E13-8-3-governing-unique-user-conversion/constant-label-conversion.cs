/*
Rules: E13-8-3-governing-unique-user-conversion; E13-8-3-switch-expression-evaluation; E13-8-3-switch-expression-conversion
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public static implicit operator long
Into: public static explicit operator long
*/
using System;
class Code
{
    readonly int value;
    public Code(int value) { this.value = value; }
    public static implicit operator long(Code code) { Program.trace = Program.trace * 10 + 2; return code.value; }
}
class Program
{
    public static int trace;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Code Make() { trace = trace * 10 + 1; return new Code(23); }
    static void Main()
    {
        int observed = 0;
        switch (Make()) { case 23: observed = 23; trace = trace * 10 + 3; break; default: observed = -1; break; }
        Check(observed == 23, "converted-constant-label");
        Check(trace == 123, "evaluate-convert-enter-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
