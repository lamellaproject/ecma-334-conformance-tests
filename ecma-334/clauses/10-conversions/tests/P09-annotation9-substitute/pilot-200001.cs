/*
Rules: P09-annotation9-substitute
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 1
Mutate: Echo<T>(T? x)=>x;
Into: Echo<T>(T? x)=>default;
*/
using System;
#nullable enable
static class Annotation9 {public static T? Echo<T>(T? x)=>x;}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Annotation9.Echo<int>(181)==181 && Annotation9.Echo<string>(null)==null, "P09-annotation9-substitute-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
