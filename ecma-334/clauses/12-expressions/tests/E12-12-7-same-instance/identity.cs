/*
Rules: E12-12-7-same-instance; E12-12-7-predefined-equality; E12-12-7-predefined-inequality; E12-12-7-inequality-complement; E12-12-7-reference-applicability
Authority: ECMA-334 7th ed 12.12.7
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: same == first
Into: same == other
*/
using System;
interface I { }
class Base { }
class Item : Base, I { public int Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Item first = new Item { Value = 3 }, same = first, other = new Item { Value = 3 }, none = null;
        Check(same == first && !(same != first), "same-instance");
        Check(first != other && !(first == other), "values-do-not-determine-reference-equality");
        Check(none == null && !(none != null), "both-null");
        Base b = first; I i = first; Check(b == i, "explicit-reference-conversion-applicability");
        i = other; Check(b != i, "different-runtime-reference");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
