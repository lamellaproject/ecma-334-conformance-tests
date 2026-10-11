/*
Rules: E12-4-3-overload-binary-right-shift
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
    public static Box operator >>(Box x, int y) { return new Box(x.value * 10 + y); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box result = new Box(11) >> 7;
        Check(result.value == 117, "binary-right-shift-invoked");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
