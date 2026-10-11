/*
Rules: E17-2-3-explicit-ilist-conversion; E17-2-3-explicit-ilist-base-conversion
Authority: ECMA-334 7th ed 17.2.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: (IList<string>)values
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
        IList<string> list = (IList<string>)values;
        ICollection<string> collection = (ICollection<string>)values;
        IEnumerable<string> sequence = (IEnumerable<string>)values;
        Check((object)list == values, "explicit-list");
        Check((object)collection == values, "explicit-collection-base");
        Check((object)sequence == values, "explicit-enumerable-base");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
