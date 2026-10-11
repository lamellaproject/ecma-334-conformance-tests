/*
Rules: E9-4-4-3-block-state-transfer
Authority: ECMA-334 7th ed 9.4.4.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: { ordinary = 24; }
Into: { }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int ordinary;
        { ordinary = 24; }
        { }
        Check(ordinary == 24, "block-assignment-and-empty-transfer");
        int checkedValue;
        checked { checkedValue = ordinary + 3; }
        checked { }
        Check(checkedValue == 27, "checked-block-entry-and-exit");
        int uncheckedValue;
        unchecked { uncheckedValue = checkedValue + 4; }
        unchecked { }
        Check(uncheckedValue == 31, "unchecked-block-entry-and-exit");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
