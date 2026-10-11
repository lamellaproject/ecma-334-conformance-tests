/*
Rules: E7-1-entry-external-selection
Authority: ECMA-334 7th ed 7.1
Version: 7.3
Expected: run
Stdout: OK 0
Fixture: {"program":{"entry_point":"Selected"}}
Mutate: class Selected
Into: class Renamed
*/
using System;
class Other
{
    static void Main() { Console.WriteLine("WRONG other-entry"); }
}
class Selected
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { if (failures == 0) Console.WriteLine("OK " + checks); }
}
