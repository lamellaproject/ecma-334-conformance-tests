/*
Rules: E15-6-5-override-accessible-protected-internal
Authority: ECMA-334 7th ed 15.6.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: protected internal override int Read()
Into: protected internal new int Read()
*/
using System;
class Root { protected internal virtual int Read() { return 47; } }
class Leaf : Root { protected internal override int Read() { return 53; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Root value = new Leaf();
        Check(value.Read() == 53, "protected-internal-base-method-accessible-for-override");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
