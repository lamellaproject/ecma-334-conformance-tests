/*
Rules: E6-4-4-grammar-keyword-1; E6-4-4-grammar-keyword-46; E6-4-4-grammar-keyword-55
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: abstract class Root
Into: class Root
*/
using System;
abstract class Root { public abstract int Read(); }
sealed class Leaf : Root { public override int Read() { return 61; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Root item = new Leaf();
        Check(item.Read() == 61, "abstract-and-concrete-declarations");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
