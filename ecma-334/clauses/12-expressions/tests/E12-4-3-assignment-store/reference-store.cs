/*
Rules: E12-4-3-assignment-store
Authority: ECMA-334 7th ed 12.4.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: left = right;
Into: left += right;
*/
using System;
class Box
{
    public static int calls;
    public static Box operator +(Box x, Box y) { calls++; return new Box(); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box left = new Box(), right = new Box(); left = right;
        Check(left == right && Box.calls == 0, "assignment-is-simple-store");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
