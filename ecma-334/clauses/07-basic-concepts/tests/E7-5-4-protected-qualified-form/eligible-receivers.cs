/*
Rules: E7-5-4-protected-qualified-form
Authority: ECMA-334 7th ed 7.5.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: protected int value = 97;
Into: private int value = 97;
*/
using System;
class Root { protected int value = 97; }
class Branch<T> : Root
{
    public static int Same(Branch<T> receiver) { return receiver.value; }
    public static int Constructed(Branch<int> receiver) { return receiver.value; }
    public static int MoreDerived(Twig receiver) { return receiver.value; }
}
class Twig : Branch<int> { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Branch<int>.Same(new Branch<int>()) == 97, "receiver-of-accessing-derived-type");
        Check(Branch<string>.Constructed(new Branch<int>()) == 97, "receiver-constructed-from-accessing-derived-class");
        Check(Branch<string>.MoreDerived(new Twig()) == 97, "receiver-derived-from-constructed-accessing-class");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
