/*
Rules: E10-2-8-delegate
Authority: ECMA-334 7th ed 10.2.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Delegate baseValue=source;
Into: Delegate baseValue=default(Delegate);
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Func<int> source=()=>61; Delegate baseValue=source; ICloneable cloneable=source;
        Check(ReferenceEquals(source,baseValue) && ReferenceEquals(source,cloneable) && ((Func<int>)baseValue)()==61, "E10-2-8-delegate-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
