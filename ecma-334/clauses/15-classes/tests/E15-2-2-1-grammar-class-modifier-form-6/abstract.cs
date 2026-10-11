/*
Rules: E15-2-2-1-grammar-class-modifier-form-6
Authority: ECMA-334 7th ed 15.2.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: abstract class Root
Into: sealed class Root
*/
using System;
abstract class Root { public int Read() { return 97; } }
class Leaf : Root { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Root root = new Leaf();
        Check(root.Read() == 97, "abstract-class-as-base");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
