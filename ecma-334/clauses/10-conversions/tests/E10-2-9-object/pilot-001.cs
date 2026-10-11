/*
Rules: E10-2-9-object; E10-2-9-valuetype; E10-2-9-interface; E10-2-9-copy; E10-3-7-object; E10-3-7-valuetype; E10-3-7-interface; E10-3-7-copy; E10-2-1-categories; E10-3-1-categories
Authority: ECMA-334 7th ed 10.2.9
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: object boxed=value;
Into: object boxed=new Counter();
*/
using System;

interface ICounter { void Change(int n); } struct Counter:ICounter { public int Number; public void Change(int n){Number=n;} }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Counter value=new Counter {Number=61}; object boxed=value; ValueType baseValue=value; ICounter view=value;
        value.Number=93;
        Counter restored=(Counter)boxed; Counter other=(Counter)baseValue; Counter fromInterface=(Counter)view;
        Check(restored.Number==61 && other.Number==61 && fromInterface.Number==61, "E10-2-9-object-pilot-001-check-01");
        restored.Number=12; view.Change(82);
        Check(((Counter)boxed).Number==61 && ((Counter)view).Number==82 && value.Number==93, "E10-2-9-object-pilot-001-check-02");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
