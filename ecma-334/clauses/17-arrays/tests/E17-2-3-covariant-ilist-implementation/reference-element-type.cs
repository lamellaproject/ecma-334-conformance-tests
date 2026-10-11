/*
Rules: E17-2-3-covariant-ilist-implementation; E17-2-3-covariant-ilist-conversion; E17-2-3-covariant-ilist-base-conversion
Authority: ECMA-334 7th ed 17.2.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: IList<object> list = values
Into: IList<object> list = null
*/
using System;
using System.Collections.Generic;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string[] values = new string[2];
        IList<object> list = values;
        ICollection<object> collection = values;
        IEnumerable<object> sequence = values;
        Check((object)list == values, "covariant-list");
        Check((object)collection == values, "covariant-collection-base");
        Check((object)sequence == values, "covariant-enumerable-base");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
