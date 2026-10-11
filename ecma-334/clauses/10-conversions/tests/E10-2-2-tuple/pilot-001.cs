/*
Rules: E10-2-2-tuple; E10-2-13-tuple; E10-2-13-order; E10-2-13-name-warning; E10-2-1-categories
Authority: ECMA-334 7th ed 10.2.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: (long x,long y) identical=pair;
Into: (long x,long y) identical=(0L,0L);
*/
using System;

static class Trace { public static string Log; public static int Next(int n) { Log+=n; return n; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Trace.Log="";
        (long left,long right) pair=(alien:Trace.Next(1),foreign:Trace.Next(2));
        (long x,long y) identical=pair;
        Check(pair.left==1 && pair.right==2 && identical.x==1 && identical.y==2 && Trace.Log=="12", "E10-2-2-tuple-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
