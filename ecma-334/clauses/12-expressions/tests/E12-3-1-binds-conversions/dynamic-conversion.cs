/*
Rules: E12-3-1-binds-conversions
Authority: ECMA-334 7th ed 12.3.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: dynamic operand = new Box(13);
Into: object operand = new Box(13);
*/
using System;
public struct Box
{
    public int value;
    public Box(int n) { value = n; }
    public static implicit operator int(Box x) { return x.value + 7; }
    public static explicit operator long(Box x) { return x.value + 9L; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic operand = new Box(13);
        int implicitValue = operand; long explicitValue = (long)operand;
        Check(implicitValue == 20, "dynamic-implicit-conversion");
        Check(explicitValue == 22L, "dynamic-explicit-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
