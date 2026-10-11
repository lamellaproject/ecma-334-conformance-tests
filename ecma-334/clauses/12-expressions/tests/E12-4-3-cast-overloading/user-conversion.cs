/*
Rules: E12-4-3-cast-overloading
Authority: ECMA-334 7th ed 12.4.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: (int)operand
Into: operand.value
*/
using System;
struct Box
{
    public int value;
    public Box(int n) { value = n; }
    public static explicit operator int(Box x) { return x.value + 20; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box operand = new Box(11); int result = (int)operand;
        Check(result == 31, "cast-uses-conversion-declaration");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
