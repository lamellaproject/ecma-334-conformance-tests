/*
Rules: E12-4-3-overload-unary-false
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
    public static int truths, falses, ands;
    public static bool operator true(Box x) { truths++; return x.value != 0; }
    public static bool operator false(Box x) { falses++; return x.value == 0; }
    public static Box operator &(Box x, Box y) { ands++; return new Box(71); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box result = new Box(0) && new Box(8);
        Check(result.value == 0 && Box.falses == 1 && Box.ands == 0, "unary-false-invoked");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
