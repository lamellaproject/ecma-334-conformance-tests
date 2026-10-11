/*
Rules: E13-9-5-dynamic-explicit-iteration-type; E13-9-5-dynamic-collection-type; E13-9-5-dynamic-enumerator-type; E13-9-5-value-iteration-value-conversion
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: run
Stdout: OK 3
Version-Witness: version-witnesses/object-cast-21a72d0b27.cs.part
Mutate: foreach (int item in collection)
Into: foreach (int item in new int[] { 42 })
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    public struct Convertible
    {
        public static explicit operator int(Convertible value) { return 99; }
    }
    static void Main()
    {
        dynamic collection = new object[] { 42, new Convertible() };
        int total = 0, caught = 0;
        try { foreach (int item in collection) { total += item; } }
        catch (InvalidCastException) { caught = 1; }
        catch (Exception) { caught = 2; }
        Check(total == 42, "first-boxed-int-unboxed");
        Check(caught == 1, "iteration-cast-from-object-not-dynamic-conversion");
        Check((int)(Convertible)((object[])collection)[1] == 99, "user-conversion-available-outside-object-cast");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
