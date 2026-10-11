/*
Rules: P13-params-collection-expand; P13-params-collection-invocation; P13-params-collection-readonly; P13-params-collection-span-array
Authority: csc 5.11.0-1.26425.128 (C# 13.0)
Version: 13.0
Expected: run
Stdout: OK 4
Mutate: Params.Sum(373,379)
Into: Params.Sum()
*/
using System;


static class Params {
    public static int Sum(params ReadOnlySpan<int> x){int s=0;foreach(int n in x)s+=n;return s;}
    public static int Pick(params ReadOnlySpan<int> x)=>1;public static int Pick(params Span<int> x)=>2;
    public static int Array(params ReadOnlySpan<int> x)=>1;public static int Array(params int[] x)=>2;
}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Params.Sum(373,379)==752, "P13-params-collection-expand-pilot-200001-check-01");
        var group=Params.Sum; Check(group(383,389)==772, "P13-params-collection-expand-pilot-200001-check-02");
        var lambda=(params ReadOnlySpan<int> items)=>items.Length;Check(lambda(397,401,409)==3, "P13-params-collection-expand-pilot-200001-check-03");
        Check(Params.Pick(419,421)==1 && Params.Array(431,433)==1, "P13-params-collection-expand-pilot-200001-check-04");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
