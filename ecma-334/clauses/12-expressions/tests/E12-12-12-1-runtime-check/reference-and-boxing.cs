/*
Rules: E12-12-12-1-runtime-check; E12-12-12-type-form; E12-12-12-1-conversion-compatibility; E12-12-12-1-runtime-type; E12-12-12-1-other-runtime-type; E12-12-12-1-reference-same-type; E12-12-12-1-reference-conversion; E12-12-12-1-boxing-conversion; E12-12-12-1-implemented-interface; E12-12-12-1-otherwise-false
Authority: ECMA-334 7th ed 12.12.12.1
Version: 7.3
Expected: run
Stdout: OK 7
Mutate: source is Derived
Into: source is Value
*/
using System;
interface I { }
class Base { }
class Derived : Base, I { }
struct Value : I { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object source = new Derived();
        Check(source is Derived, "same-runtime-reference-type");
        Check(source is Base, "implicit-base-reference-conversion");
        Check(source is I, "implicit-interface-reference-conversion");
        source = new Base(); Check(!(source is I), "missing-interface");
        Value value = new Value(); Check(value is object, "value-boxing-conversion");
        source = value; Check(source is I, "boxed-value-implements-interface");
        source = 3; Check(!(source is Value), "unrelated-value-runtime-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
