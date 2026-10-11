/*
Rules: E12-4-3-user-defined-precedence; E12-4-3-user-defined-declarations; E12-4-1-user-defined-operands; E12-4-3-expression-notation; E12-4-3-declaration-notation; E12-4-3-prefix-functional; E12-4-3-binary-functional; E12-4-4-unary-candidates; E12-4-4-unary-user-candidates; E12-4-4-unary-best; E12-4-5-binary-user-candidates; E12-4-5-binary-best; E12-4-6-nonnullable-type; E12-4-6-applicable-declared; E12-6-1-category-operators
Authority: ECMA-334 7th ed 12.4.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public static int operator +(Box x, int y) { return x.value * y; }
Into: public static int operator -(Box x, int y) { return x.value * y; }
*/
using System;
struct Box
{
    public int value;
    public Box(int n) { value = n; }
    public static implicit operator int(Box x) { return x.value; }
    public static int operator +(Box x) { return x.value + 100; }
    public static int operator +(Box x, int y) { return x.value * y; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box operand = new Box(9);
        Check(+operand == 109, "unary-user-before-predefined");
        Check(operand + 7 == 63, "binary-user-before-predefined");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
