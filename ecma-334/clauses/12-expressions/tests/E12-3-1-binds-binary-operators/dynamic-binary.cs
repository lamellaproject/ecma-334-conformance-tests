/*
Rules: E12-3-1-binds-binary-operators
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
    public static int operator +(Box x, int y) { return x.value * y; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic operand = new Box(13);
        int value = operand + 3;
        Check(value == 39, "dynamic-binary-overload");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
