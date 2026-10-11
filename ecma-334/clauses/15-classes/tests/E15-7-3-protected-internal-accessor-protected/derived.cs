/*
Rules: E15-7-3-protected-internal-accessor-protected
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: protected set
Into: private set
*/
using System;
class Base { int slot; protected internal int Item { get { return slot; } protected set { slot = value; } } }
class Derived : Base { public void Write() { Item = 36; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { Derived box = new Derived(); box.Write(); Check(box.Item == 36, "protected-internal-protected-set"); if (failures == 0) Console.WriteLine("OK " + checks); }
}
