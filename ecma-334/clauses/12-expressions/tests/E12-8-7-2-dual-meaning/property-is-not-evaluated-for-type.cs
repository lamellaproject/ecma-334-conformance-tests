/*
Rules: E12-8-7-2-dual-meaning; E12-8-7-2-static-access
Authority: ECMA-334 7th ed 12.8.7.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: return Cell.Value;
Into: return Cell.Read();
*/
using System;
class Cell { public static int Value = 3; public int Read() { return 8; } }
class Owner
{
    public int calls;
    public Cell Cell { get { calls++; throw new InvalidOperationException(); } }
    public int Resolve() { return Cell.Value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Owner owner = new Owner();
        Check(owner.Resolve() == 3, "dual-property-name-allows-static-member");
        Check(owner.calls == 0, "type-meaning-does-not-evaluate-property-meaning");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
