/*
Rules: E12-4-8-unary-lifted-value; E12-4-8-nullable-operators; E12-4-8-unary-lifting; E12-4-8-unary-lifted-signature; E12-4-8-unary-lifted-null; E12-4-6-nullable-underlying
Authority: ECMA-334 7th ed 12.4.8
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: -value
Into: value
*/
using System;
struct Box
{
    public int value; public static int calls;
    public Box(int n) { value = n; }
    public static Box operator -(Box x) { calls++; return new Box(x.value + 17); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box? value = new Box(8); Box? result = -value;
        Check(result.HasValue && result.Value.value == 25 && Box.calls == 1, "lifted-unary-wraps-result");
        Box? empty = null; Box? absent = -empty;
        Check(absent == null && Box.calls == 1, "lifted-unary-null-skips-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
