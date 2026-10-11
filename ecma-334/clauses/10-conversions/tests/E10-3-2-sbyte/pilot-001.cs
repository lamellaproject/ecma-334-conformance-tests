/*
Rules: E10-3-2-sbyte; E10-3-2-all-pairs
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: sbyte x=61;
Into: sbyte x=default(sbyte);
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        sbyte x=61;
        Check((byte)x==61 && (ushort)x==61 && (uint)x==61 && (ulong)x==61 && (char)x=='=', "E10-3-2-sbyte-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
