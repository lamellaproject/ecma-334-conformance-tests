/*
Rules: P10-natural-preference
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 1
Mutate: Natural.Pick((int x)=>x)
Into: Natural.Pick((Delegate)(Func<int,int>)((int x)=>x))
*/
using System;

static class Natural{public static int Pick(Func<int,int> f)=>1;public static int Pick(Delegate f)=>2;}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Natural.Pick((int x)=>x)==1, "P10-natural-preference-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
