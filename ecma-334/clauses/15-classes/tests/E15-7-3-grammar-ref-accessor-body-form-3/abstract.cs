/*
Rules: E15-7-3-grammar-ref-accessor-body-form-3
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: abstract ref int Item
Into: virtual ref int Item
*/
using System;
abstract class Base { public abstract ref int Item { get; } }
class Derived : Base { int slot = 19; public override ref int Item { get { return ref slot; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { Base box = new Derived(); Check(box.Item == 19, "abstract-ref-semicolon"); if (failures == 0) Console.WriteLine("OK " + checks); }
}
