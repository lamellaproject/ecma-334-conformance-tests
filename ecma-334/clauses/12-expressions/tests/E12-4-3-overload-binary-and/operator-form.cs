/*
Rules: E12-4-3-overload-binary-and
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
    public static Box operator &(Box x, Box y) { return new Box(x.value * 10 + y.value); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box result = new Box(11) & new Box(7);
        Check(result.value == 117, "binary-and-invoked");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
