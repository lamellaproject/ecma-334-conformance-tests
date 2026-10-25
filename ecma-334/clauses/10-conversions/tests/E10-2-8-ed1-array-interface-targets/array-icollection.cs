/*
Rules: E10-2-8-ed1-array-interface-targets
Authority: ECMA-334 1st ed 13.1.4
Version: ISO-1
Expected: reject
Version-Witness: tests/E10-2-8-ed1-array-interface-targets/array-icollection.witness.cs.part
Mutate: view = new int[0]
Into: view = (System.Array)new int[0]
*/
// ECMA-334 1st ed 13.1.4, p. 114 (PDF p. 128), lines 18-31. The closed implicit-reference
// conversion list gives an array conversion to System.Array and System.ICloneable, but not
// a direct array conversion to IEnumerable, ICollection or IList.
class Entry
{
    static void Main()
    {
        System.Collections.ICollection view = new int[0];
        System.Console.WriteLine(view != null ? "OK 0" : "FAIL");
    }
}
