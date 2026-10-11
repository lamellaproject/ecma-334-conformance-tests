/*
Rules: E10-3-2-checked-integral; E10-3-2-checked-overflow; E10-3-1-may-fail; E12-8-19-checked-range
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: byte a=checked((byte)fit);
Into: byte a=0;
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int fit=255; int excess=256;
        byte a=checked((byte)fit); Check(a==255, "E10-3-2-checked-integral-pilot-001-check-01");
        try { byte b=checked((byte)excess); Check(false, "E10-3-2-checked-integral-pilot-001-check-02"); } catch (OverflowException) { Check(true, "E10-3-2-checked-integral-pilot-001-check-02"); } catch (Exception error) { Check(false, "E10-3-2-checked-integral-unexpected-exception-1"); Console.WriteLine("EXCEPTION " + error.GetType().FullName); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
