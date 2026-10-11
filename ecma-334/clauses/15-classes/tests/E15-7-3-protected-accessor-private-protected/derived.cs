/*
Rules: E15-7-3-protected-accessor-private-protected
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: private protected set
Into: private set
*/
using System;
class Base { int slot; protected int Item { get { return slot; } private protected set { slot = value; } } }
class Derived : Base { public int Write() { Item = 43; return Item; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { Check(new Derived().Write() == 43, "protected-private-protected-set"); if (failures == 0) Console.WriteLine("OK " + checks); }
}
