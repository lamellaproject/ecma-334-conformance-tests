/*
Rules: E15-3-4-transitive-inheritance; E15-3-4-instance-includes-base-fields; E15-3-4-derived-base-conversion
Authority: ECMA-334 7th ed 15.3.4
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: class Middle : Root
Into: class Middle
*/
using System;
class Root { public int RootField; }
class Middle : Root { public int MiddleField; }
class Leaf : Middle { public int LeafField; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Leaf value = new Leaf();
        Root root = value;
        Middle middle = value;
        value.RootField = 283;
        middle.MiddleField = 293;
        value.LeafField = 307;
        Check(root.RootField == 283, "transitive-base-field-stored-in-leaf");
        Check(value.MiddleField == 293, "direct-base-field-stored-in-leaf");
        Check(value.LeafField == 307, "leaf-field-distinct-from-base-fields");
        Check((object)root == (object)value && (object)middle == (object)value, "implicit-base-conversions-preserve-instance");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
