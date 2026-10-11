/*
Rules: E17-2-3-explicit-readonlylist-conversion; E17-2-3-explicit-readonlylist-base-conversion
Authority: ECMA-334 7th ed 17.2.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: (IReadOnlyList<string>)values
Into: values
*/
using System;
using System.Collections.Generic;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object[] values = new string[2];
        IReadOnlyList<string> list = (IReadOnlyList<string>)values;
        IReadOnlyCollection<string> collection = (IReadOnlyCollection<string>)values;
        IEnumerable<string> sequence = (IEnumerable<string>)values;
        Check((object)list == values, "explicit-readonly-list");
        Check((object)collection == values, "explicit-readonly-base");
        Check((object)sequence == values, "explicit-enumerable-base");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
