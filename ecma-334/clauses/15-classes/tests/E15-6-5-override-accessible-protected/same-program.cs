/*
Rules: E15-6-5-override-accessible-protected; E15-6-5-override-base-access
Authority: ECMA-334 7th ed 15.6.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: protected override int Read()
Into: protected new int Read()
*/
using System;
class Root
{
    protected virtual int Read() { return 41; }
    public int Invoke() { return Read(); }
}
class Leaf : Root { protected override int Read() { return base.Read() + 2; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Root value = new Leaf();
        Check(value.Invoke() == 43, "protected-base-method-accessible-for-override-and-base-access");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
