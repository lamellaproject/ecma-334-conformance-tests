/*
Rules: E17-2-3-ilist-array-explicit; E17-2-3-ilist-base-array-explicit
Authority: ECMA-334 7th ed 17.2.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: (string[])list
Into: list
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
        ICollection<object> collection = list;
        IEnumerable<object> sequence = list;
        string[] fromList = (string[])list;
        string[] fromCollection = (string[])collection;
        string[] fromSequence = (string[])sequence;
        Check(fromList == values, "list-back-to-array");
        Check(fromCollection == values, "collection-back-to-array");
        Check(fromSequence == values, "enumerable-back-to-array");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
