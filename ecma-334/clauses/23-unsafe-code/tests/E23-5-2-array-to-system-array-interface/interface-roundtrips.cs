/*
Rules: E23-5-2-array-to-system-array-interface; E23-5-2-system-array-interface-to-pointer-array
Authority: ECMA-334 7th ed 23.5.2
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: System.Collections.IList list = items;
Into: System.Collections.IList list = new int*[0];
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int*[] items = new int*[2];
        System.Collections.IList list = items;
        System.Collections.ICollection collection = items;
        System.Collections.IEnumerable enumerable = items;
        ICloneable cloneable = items;
        Check((int*[])list == items, "ilist-pointer-array-roundtrip");
        Check((int*[])collection == items, "icollection-pointer-array-roundtrip");
        Check((int*[])enumerable == items, "ienumerable-pointer-array-roundtrip");
        Check((int*[])cloneable == items, "icloneable-pointer-array-roundtrip");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
