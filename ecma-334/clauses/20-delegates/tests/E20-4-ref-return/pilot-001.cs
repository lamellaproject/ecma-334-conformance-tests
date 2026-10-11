/*
Rules: E20-4-ref-return
Authority: ECMA-334 7th ed 20.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: ReadRef converted=Bridge.Read;
Into: ReadRef converted=default(ReadRef);
*/
using System;


delegate ref int ReadRef(); delegate ref readonly int ReadOnlyRef();
static class Bridge {public static int Number=61;public static ref int Read(){return ref Number;} public static ref readonly int ReadOnly(){return ref Number;} }

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        ReadRef converted=Bridge.Read; ref int value=ref converted(); value=82;
        ReadOnlyRef readOnly=Bridge.ReadOnly;
        Check(Bridge.Number==82 && readOnly()==82, "E20-4-ref-return-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
