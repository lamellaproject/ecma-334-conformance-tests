/*
Rules: E12-3-1-binds-unary-operators; E12-3-1-operator-binding-types
Authority: ECMA-334 7th ed 12.3.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: dynamic operand = new Box(13);
Into: object operand = new Box(13);
*/
using System;
public struct Box
{
    public int value;
    public Box(int n) { value = n; }
    public static int operator -(Box x) { return x.value + 7; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic operand = new Box(13);
        int value = -operand;
        Check(value == 20, "dynamic-unary-overload");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
