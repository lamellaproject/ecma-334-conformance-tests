/*
Rules: E17-2-3-ilist-implementation; E17-2-3-ilist-base-implementation; E17-2-3-ilist-implicit; E17-2-3-ilist-base-implicit
Authority: ECMA-334 7th ed 17.2.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: IList<int> list = values
Into: IList<int> list = null
*/
using System;
using System.Collections.Generic;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] values = new int[2];
        IList<int> list = values;
        ICollection<int> collection = values;
        IEnumerable<int> sequence = values;
        Check((object)list == values, "list-implementation-and-conversion");
        Check((object)collection == values, "collection-base-conversion");
        Check((object)sequence == values, "enumerable-base-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
