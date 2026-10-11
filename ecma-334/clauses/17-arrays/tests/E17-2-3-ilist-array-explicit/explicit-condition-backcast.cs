/*
Rules: E17-2-3-ilist-array-explicit; E17-2-3-ilist-base-array-explicit
Authority: ECMA-334 7th ed 17.2.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: (object[])list
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
        object[] values = new string[2];
        IList<string> list = (IList<string>)values;
        ICollection<string> collection = list;
        IEnumerable<string> sequence = list;
        object[] fromList = (object[])list;
        object[] fromCollection = (object[])collection;
        object[] fromSequence = (object[])sequence;
        Check(fromList == values, "explicit-condition-list-backcast");
        Check(fromCollection == values, "explicit-condition-collection-backcast");
        Check(fromSequence == values, "explicit-condition-enumerable-backcast");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
