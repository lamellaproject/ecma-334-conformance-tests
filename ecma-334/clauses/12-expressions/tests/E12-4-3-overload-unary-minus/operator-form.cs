/*
Rules: E12-4-3-overload-unary-minus
Authority: ECMA-334 7th ed 12.4.3
Version: 7.3
Expected: run
Stdout: OK 1
Generated: clauses/12-expressions/generators/operator-forms.py
*/
using System;
struct Box
{
    public int value;
    public Box(int n) { value = n; }
    public static Box operator -(Box x) { return new Box(x.value + 40); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box operand = new Box(11); Box result = -operand;
        Check(result.value == 51, "unary-minus-invoked");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
