/*
Rules: P12-collection-inference
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: run
Stdout: OK 1
Mutate: Inferred.Echo([199,211])
Into: new int[]{0,0}
*/
using System;

static class Inferred{public static T[] Echo<T>(T[] values)=>values;}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var values=Inferred.Echo([199,211]); Check(values is int[] && values[1]==211, "P12-collection-inference-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
