/*
Rules: E17-2-3-covariant-readonlylist-implementation; E17-2-3-covariant-readonlylist-conversion; E17-2-3-covariant-readonlylist-base-conversion
Authority: ECMA-334 7th ed 17.2.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: IReadOnlyList<object> list = values
Into: IReadOnlyList<object> list = null
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
        IReadOnlyList<object> list = values;
        IReadOnlyCollection<object> collection = values;
        IEnumerable<object> sequence = values;
        Check((object)list == values, "covariant-readonly-list");
        Check((object)collection == values, "covariant-readonly-base");
        Check((object)sequence == values, "covariant-enumerable-base");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
