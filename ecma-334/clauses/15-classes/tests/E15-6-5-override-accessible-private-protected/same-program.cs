/*
Rules: E15-6-5-override-accessible-private-protected
Authority: ECMA-334 7th ed 15.6.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: private protected override int Read()
Into: private protected new int Read()
*/
using System;
class Root
{
    private protected virtual int Read() { return 67; }
    public int Invoke() { return Read(); }
}
class Leaf : Root { private protected override int Read() { return 71; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Root value = new Leaf();
        Check(value.Invoke() == 71, "same-program-private-protected-method-accessible-for-override");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
