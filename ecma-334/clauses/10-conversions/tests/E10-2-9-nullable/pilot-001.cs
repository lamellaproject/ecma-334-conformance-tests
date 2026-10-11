/*
Rules: E10-2-9-nullable; E10-2-9-nullable-null; E10-2-9-nullable-value; E10-3-7-nullable; E10-3-7-nullable-null; E10-3-7-nullable-value
Authority: ECMA-334 7th ed 10.2.9
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: object box=filled, absent=empty;
Into: object box=(int?)62, absent=empty;
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int? filled=61, empty=null;
        object box=filled, absent=empty; IComparable comparable=filled; ValueType value=filled;
        int? restored=(int?)box, missing=(int?)absent, fromInterface=(int?)comparable;
        Check(box.GetType()==typeof(int) && absent==null && restored.Value==61 && !missing.HasValue && fromInterface.Value==61, "E10-2-9-nullable-pilot-001-check-01");
        Check((int)value==61, "E10-2-9-nullable-pilot-001-check-02");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
