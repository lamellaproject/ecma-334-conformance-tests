/*
Rules: E17-2-3-readonlylist-implementation; E17-2-3-readonlylist-base-implementation; E17-2-3-readonlylist-implicit; E17-2-3-readonlylist-base-implicit
Authority: ECMA-334 7th ed 17.2.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: IReadOnlyList<int> list = values
Into: IReadOnlyList<int> list = null
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
        IReadOnlyList<int> list = values;
        IReadOnlyCollection<int> collection = values;
        IEnumerable<int> sequence = values;
        Check((object)list == values, "readonly-list");
        Check((object)collection == values, "readonly-collection-base");
        Check((object)sequence == values, "readonly-enumerable-base");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
