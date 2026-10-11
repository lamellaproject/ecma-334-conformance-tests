/*
Rules: E15-7-6-override-property-type-identity
Authority: ECMA-334 7th ed 15.7.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: override dynamic Item
Into: override string Item
*/
using System;
class Base { public virtual object Item { get { return null; } } }
class Derived : Base { public override dynamic Item { get { return 39; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { Base box = new Derived(); object value = box.Item; Check((int)value == 39, "dynamic-object-identity-override"); if (failures == 0) Console.WriteLine("OK " + checks); }
}
