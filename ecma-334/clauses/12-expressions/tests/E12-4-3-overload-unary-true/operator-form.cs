/*
Rules: E12-4-3-overload-unary-true
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
        int result = 0; if (new Box(5)) result = 1;
        Check(result == 1 && Box.truths == 1 && Box.falses == 0, "unary-true-invoked");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
