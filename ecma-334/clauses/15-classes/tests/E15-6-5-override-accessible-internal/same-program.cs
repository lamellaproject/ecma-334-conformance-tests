/*
Rules: E15-6-5-override-accessible-internal
Authority: ECMA-334 7th ed 15.6.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: internal override int Read()
Into: internal new int Read()
*/
using System;
class Root { internal virtual int Read() { return 59; } }
class Leaf : Root { internal override int Read() { return 61; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Root value = new Leaf();
        Check(value.Read() == 61, "same-program-internal-method-accessible-for-override");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
