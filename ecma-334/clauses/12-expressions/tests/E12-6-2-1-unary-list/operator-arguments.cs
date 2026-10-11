/*
Rules: E12-6-2-1-unary-list; E12-6-2-1-binary-list; E12-6-2-2-unary-correspondence; E12-6-2-2-binary-left-correspondence; E12-6-2-2-binary-right-correspondence
Authority: ECMA-334 7th ed 12.6.2.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Box result = left + right;
Into: Box result = right + left;
*/
using System;
struct Box
{
    public int value;
    public Box(int n) { value = n; }
    public static Box operator -(Box operand) { return new Box(operand.value + 10); }
    public static Box operator +(Box first, Box second) { return new Box(first.value * 10 + second.value); }
    public static explicit operator int(Box operand) { return operand.value + 20; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box left = new Box(3), right = new Box(7); Box result = left + right; Box unary = -left;
        Check(result.value == 37, "binary-left-right-parameter-order");
        Check(unary.value == 13, "unary-single-operand-parameter");
        Check((int)right == 27, "conversion-single-operand-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
