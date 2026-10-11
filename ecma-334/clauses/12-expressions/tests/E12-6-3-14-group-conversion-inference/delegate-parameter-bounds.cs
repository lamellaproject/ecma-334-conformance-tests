/*
Rules: E12-6-3-14-group-conversion-inference; E12-6-3-14-group-compatibility; E12-6-3-14-group-types-only; E12-6-3-14-group-initial-state; E12-6-3-14-group-lower-bounds; E12-6-3-14-group-fixing
Authority: ECMA-334 7th ed 12.6.3.14
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Func<Leaf, Root> function = Echo;
Into: Func<Leaf, Root> function = Echo<Root>;
*/
using System;
class Root { }
class Leaf : Root { }
class Program
{
    static int checks, failures;
    static bool inferredLeaf;
    static T Echo<T>(T value) { inferredLeaf = typeof(T) == typeof(Leaf); return value; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Func<Leaf, Root> function = Echo;
        Leaf leaf = new Leaf();
        Root result = function(leaf);
        Check(inferredLeaf, "delegate-input-bounds-fix-generic-type-without-return-target-inference");
        Check(object.ReferenceEquals(result, leaf), "inferred-method-is-compatible-with-covariant-return");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
