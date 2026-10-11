/*
Rules: E10-3-6-tuple; E10-3-6-order; E12-9-7-cast; E10-3-1-categories
Authority: ECMA-334 7th ed 10.3.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: ((byte,short))(Trace.Next(317),Trace.Next(62))
Into: (0,0)
*/
using System;

static class Trace { public static string Log; public static int Next(int n) { Log+=n+";"; return n; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Trace.Log="";
        (byte a,short b) pair=((byte,short))(Trace.Next(317),Trace.Next(62));
        Check(pair.a==61 && pair.b==62 && Trace.Log=="317;62;", "E10-3-6-tuple-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
