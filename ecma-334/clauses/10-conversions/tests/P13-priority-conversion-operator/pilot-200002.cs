/*
Rules: P13-priority-conversion-operator
Authority: csc 5.11.0-1.26425.128 (C# 13.0)
Version: 13.0
Expected: run
Stdout: OK 1
Mutate: OverloadResolutionPriority(2)
Into: OverloadResolutionPriority(-1)
*/
using System;

static class Priority{[System.Runtime.CompilerServices.OverloadResolutionPriority(2)]public static int Read(object x)=>853;public static int Read(string x)=>857;}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Priority.Read("slate")==853, "P13-priority-conversion-operator-pilot-200002-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
