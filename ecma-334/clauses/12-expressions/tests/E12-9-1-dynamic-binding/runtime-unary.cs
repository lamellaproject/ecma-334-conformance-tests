/*
Rules: E12-9-1-dynamic-binding; E12-9-1-dynamic-result-type; E12-9-1-dynamic-runtime-resolution
Authority: ECMA-334 7th ed 12.9.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: -operand
Into: +operand
*/
using System;
public class Answer { public int Value; public Answer(int v) { Value = v; } }
public class Number
{
    public static Answer operator -(Number x) { Program.Calls++; return new Answer(23); }
    public static Answer operator +(Number x) { return new Answer(0); }
}
class Program
{
    public static int Calls;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Pick(Answer x) { return 1; }
    static int Pick(object x) { return 2; }
    static void Main()
    {
        dynamic operand = new Number(); var result = -operand;
        Check(result.Value == 23, "runtime-operator"); Check(Calls == 1, "operator-once");
        Check(Pick(result) == 1, "dynamic-result-selects-runtime-overload");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
