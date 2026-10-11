/*
Rules: E12-4-4-unary-dynamic-ambiguous
Authority: ECMA-334 7th ed 12.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: +operand
Into: +(decimal)operand
*/
using System;
public struct Box
{
    public static implicit operator double(Box x) { return 3.0; }
    public static implicit operator decimal(Box x) { return 5M; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic operand = new Box(); bool caught = false;
        try { var result = +operand; }
        catch (Exception) { caught = true; }
        Check(caught, "dynamic-unary-binding-error");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
