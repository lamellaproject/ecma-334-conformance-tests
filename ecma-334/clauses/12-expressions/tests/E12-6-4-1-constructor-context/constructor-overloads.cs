/*
Rules: E12-6-4-1-constructor-context
Authority: ECMA-334 7th ed 12.6.4.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: new Box((short)8)
Into: new Box(8L)
*/
using System;
class Box
{
    public int selected;
    public Box(int x) { selected = 1; }
    public Box(long x) { selected = 2; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Box((short)8).selected == 1, "constructor-better-target-int");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
