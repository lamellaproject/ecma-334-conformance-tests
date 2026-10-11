/*
Rules: E10-3-2-byte; E10-3-2-all-pairs
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: byte x=61;
Into: byte x=default(byte);
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        byte x=61; Check((sbyte)x==61 && (char)x=='=', "E10-3-2-byte-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
