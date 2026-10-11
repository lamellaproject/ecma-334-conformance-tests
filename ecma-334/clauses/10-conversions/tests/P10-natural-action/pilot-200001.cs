/*
Rules: P10-natural-action
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 2
Mutate: var action=(int x)=>{Natural.Last=x;};
Into: Action<int> action=(int x)=>{};
*/
using System;

static class Natural{public static int Last;}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var action=(int x)=>{Natural.Last=x;}; Check(action.GetType()==typeof(Action<int>), "P10-natural-action-pilot-200001-check-01"); action(167); Check(Natural.Last==167, "P10-natural-action-pilot-200001-check-02");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
