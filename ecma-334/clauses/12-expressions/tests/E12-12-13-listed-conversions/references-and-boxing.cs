/*
Rules: E12-12-13-listed-conversions; E12-12-13-conversion-purpose; E12-12-13-null-literal
Authority: ECMA-334 7th ed 12.12.13
Version: 7.3
Expected: run
Stdout: OK 7
Mutate: original as Derived
Into: null as Derived
*/
using System;
interface I { }
class Base { }
class Derived : Base, I { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Derived original = new Derived(); Base b = original;
        Check((object)(original as Derived) == original, "identity-conversion");
        Check((object)(original as Base) == original, "implicit-reference-conversion");
        Check((object)(b as Derived) == original, "explicit-reference-conversion");
        Check((object)(b as I) == original, "interface-reference-conversion");
        int value = 3; object boxed = value as object; Check((int)boxed == 3, "boxing-conversion");
        Check(null as Derived == null, "null-literal-reference-target");
        Check(!(null as int?).HasValue, "null-literal-nullable-target");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
