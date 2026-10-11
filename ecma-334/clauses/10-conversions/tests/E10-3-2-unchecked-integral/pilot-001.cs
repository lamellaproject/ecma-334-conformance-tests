/*
Rules: E10-3-2-unchecked-integral; E10-3-2-truncate; E10-3-2-reinterpret; E12-8-19-unchecked-constant; E12-8-19-nonconstant-default
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: byte low=unchecked((byte)high);
Into: byte low=0;
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int high=0x1234; int negative=-1;
        byte low=unchecked((byte)high); uint bits=unchecked((uint)negative);
        byte normal=(byte)high; const byte constant=unchecked((byte)0x1234);
        Check(low==0x34 && bits==uint.MaxValue && normal==0x34 && constant==0x34, "E10-3-2-unchecked-integral-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
