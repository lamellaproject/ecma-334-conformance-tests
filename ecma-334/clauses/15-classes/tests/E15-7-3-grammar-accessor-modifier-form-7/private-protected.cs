/*
Rules: E15-7-3-grammar-accessor-modifier-form-7; E15-7-3-public-accessor-private-protected
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: private protected set
Into: private set
*/
using System;
class Base { int slot; public int Item { get { return slot; } private protected set { slot = value; } } }
class Derived : Base { public void Write() { Item = 46; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { Derived box = new Derived(); box.Write(); Check(box.Item == 46, "public-private-protected-set"); if (failures == 0) Console.WriteLine("OK " + checks); }
}
