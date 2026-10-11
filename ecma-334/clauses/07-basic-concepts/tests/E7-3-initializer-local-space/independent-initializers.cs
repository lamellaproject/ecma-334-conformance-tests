/*
Rules: E7-3-initializer-local-space
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: 23 is int temporary
Into: 23 is int renamed
*/
using System;
class Holder
{
    public int First = (object)17 is int temporary ? temporary : 0;
    public int Second = (object)23 is int temporary ? temporary : 0;
    public int Third { get; } = (object)29 is int temporary ? temporary : 0;
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var value = new Holder();
        Check(value.First == 17, "first-initializer-space");
        Check(value.Second == 23, "second-initializer-space");
        Check(value.Third == 29, "property-initializer-space");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
