/*
Rules: E12-4-8-relational-values; E12-4-8-relational-lifting; E12-4-8-relational-lifted-signature; E12-4-8-relational-null
Authority: ECMA-334 7th ed 12.4.8
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: bool less = left < right;
Into: bool less = left > right;
*/
using System;
struct Box
{
    public int value; public static int calls;
    public Box(int n) { value = n; }
    public static bool operator <(Box x, Box y) { calls++; return x.value > y.value; }
    public static bool operator >(Box x, Box y) { calls++; return x.value < y.value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box? left = new Box(11), right = new Box(8), empty = null; bool less = left < right;
        Check(less && Box.calls == 1, "lifted-relation-underlying-result");
        Check(!(empty < left) && !(left > empty), "lifted-relation-one-null");
        Check(!(empty < (Box?)null) && !(empty > (Box?)null), "lifted-relation-two-nulls");
        Check(Box.calls == 1, "null-relation-skips-underlying");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
