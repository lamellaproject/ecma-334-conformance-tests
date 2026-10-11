/*
Rules: E12-4-3-postfix-functional
Authority: ECMA-334 7th ed 12.4.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Box previous = operand++;
Into: Box previous = ++operand;
*/
using System;
struct Box
{
    public int value;
    public Box(int n) { value = n; }
    public static Box operator ++(Box x) { return new Box(x.value + 17); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box operand = new Box(9); Box previous = operand++;
        Check(previous.value == 9, "postfix-returns-old-value");
        Check(operand.value == 26, "postfix-calls-functional-operator");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
