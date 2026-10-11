/*
Rules: E10-3-2-double; E10-3-2-all-pairs
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: double x=61.875d;
Into: double x=default(double);
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        double x=61.875d;
        Check((sbyte)x==61 && (byte)x==61 && (short)x==61 && (ushort)x==61 && (int)x==61 && (uint)x==61 && (long)x==61 && (ulong)x==61 && (char)x=='=', "E10-3-2-double-pilot-001-check-01");
        Check((float)x==61.875f && (decimal)x==61.875m, "E10-3-2-double-pilot-001-check-02");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
