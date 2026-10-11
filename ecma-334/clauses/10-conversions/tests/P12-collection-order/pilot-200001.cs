/*
Rules: P12-collection-order
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: run
Stdout: OK 1
Mutate: int[] values=[Events.Read(157),Events.Read(163),Events.Read(167)];
Into: int[] values=default(int[]);
*/
using System;

static class Events{public static string Log="";public static int Read(int n){Log+=n+";";return n;}}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] values=[Events.Read(157),Events.Read(163),Events.Read(167)]; Check(Events.Log=="157;163;167;" && values[0]==157 && values[2]==167, "P12-collection-order-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
