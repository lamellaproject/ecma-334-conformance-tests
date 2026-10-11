/*
Rules: E12-6-6-1-bound-before-invocation
Authority: ECMA-334 7th ed 12.6.6.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Pick(value)
Into: Pick((Leaf)value)
*/
using System;
class Root { }
class Leaf : Root { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Pick(Root value) { return 3; }
    static int Pick(Leaf value) { return 8; }
    static void Main()
    {
        Root value = new Leaf();
        int result = Pick(value);
        Check(result == 3, "runtime-receiver-type-does-not-rebind-static-overload");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
