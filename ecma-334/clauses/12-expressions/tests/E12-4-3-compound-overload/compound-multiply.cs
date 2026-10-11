/*
Rules: E12-4-3-compound-overload
Authority: ECMA-334 7th ed 12.4.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: operand *= 3;
Into: operand = new Box(3);
*/
using System;
struct Box
{
    public int value;
    public Box(int n) { value = n; }
    public static Box operator *(Box x, int y) { return new Box(x.value + y + 20); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box operand = new Box(11); operand *= 3;
        Check(operand.value == 34, "compound-uses-binary-overload");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
