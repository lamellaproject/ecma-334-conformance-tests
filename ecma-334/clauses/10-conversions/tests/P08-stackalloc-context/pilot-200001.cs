/*
Rules: P08-stackalloc-context; P08-stackalloc-span
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 1
Mutate: Span<int> direct=stackalloc int[3];
Into: Span<int> direct=default(Span<int>);
*/
using System;

static class Nested {public static int Sum(Span<int> x)=>x[0]+x[1];}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Span<int> direct=stackalloc int[3]; direct[2]=311;
        int sum=Nested.Sum(stackalloc int[]{29,37});
        ReadOnlySpan<int> ro=stackalloc int[]{43,53};
        Check(direct[2]==311 && sum==66 && ro[0]+ro[1]==96, "P08-stackalloc-context-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
