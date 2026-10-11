/*
Rules: E15-7-3-grammar-accessor-modifier-form-6; E15-7-3-public-accessor-private-protected
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: protected private set
Into: private set
*/
using System;
class Base { int slot; public int Item { get { return slot; } protected private set { slot = value; } } }
class Derived : Base { public void Write() { Item = 29; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { Derived box = new Derived(); box.Write(); Check(box.Item == 29, "public-protected-private-set"); if (failures == 0) Console.WriteLine("OK " + checks); }
}
