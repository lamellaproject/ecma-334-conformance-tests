/*
Rules: E10-3-2-float; E10-3-2-all-pairs; E10-3-2-float-truncate-checked; E10-3-2-float-truncate-unchecked
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: float x=61.875f;
Into: float x=default(float);
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        float x=61.875f;
        Check((sbyte)x==61 && (byte)x==61 && (short)x==61 && (ushort)x==61 && (int)x==61 && (uint)x==61 && (long)x==61 && (ulong)x==61 && (char)x=='=', "E10-3-2-float-pilot-001-check-01");
        Check((decimal)x==61.875m && checked((int)-x)==-61, "E10-3-2-float-pilot-001-check-02");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
