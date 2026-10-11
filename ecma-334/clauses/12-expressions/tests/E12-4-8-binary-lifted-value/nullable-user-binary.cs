/*
Rules: E12-4-8-binary-lifted-value; E12-4-8-binary-lifting; E12-4-8-binary-lifted-signature; E12-4-8-binary-lifted-null
Authority: ECMA-334 7th ed 12.4.8
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: left + right
Into: left
*/
using System;
struct Box
{
    public int value; public static int calls;
    public Box(int n) { value = n; }
    public static Box operator +(Box x, Box y) { calls++; return new Box(x.value * 10 + y.value); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box? left = new Box(8), right = new Box(3), empty = null; Box? result = left + right;
        Check(result.HasValue && result.Value.value == 83 && Box.calls == 1, "lifted-binary-wraps-result");
        Check((empty + left) == null, "lifted-binary-left-null");
        Check((right + empty) == null, "lifted-binary-right-null");
        Check((empty + empty) == null && Box.calls == 1, "lifted-binary-two-nulls");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
