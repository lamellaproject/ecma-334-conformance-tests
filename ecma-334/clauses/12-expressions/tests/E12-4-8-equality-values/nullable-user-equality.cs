/*
Rules: E12-4-8-equality-values; E12-4-8-equality-lifting; E12-4-8-equality-lifted-signature; E12-4-8-equality-two-nulls; E12-4-8-equality-one-null
Authority: ECMA-334 7th ed 12.4.8
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: bool equal = left == right;
Into: bool equal = left != right;
*/
using System;
struct Box
{
    public int value; public static int calls;
    public Box(int n) { value = n; }
    public static bool operator ==(Box x, Box y) { calls++; return x.value % 3 == y.value % 3; }
    public static bool operator !=(Box x, Box y) { calls++; return x.value % 3 != y.value % 3; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box? left = new Box(8), right = new Box(11), empty = null; bool equal = left == right;
        Check(equal && Box.calls == 1, "lifted-equality-calls-underlying");
        Check(empty == (Box?)null && !(empty != (Box?)null), "lifted-equality-two-nulls");
        Check(!(empty == left) && left != empty, "lifted-equality-one-null");
        Check(Box.calls == 1, "null-equality-skips-underlying");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
