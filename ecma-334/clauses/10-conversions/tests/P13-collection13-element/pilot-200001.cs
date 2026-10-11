/*
Rules: P13-collection13-element; P13-collection13-nonspan; P13-collection13-readonly; P13-collection13-span-array
Authority: csc 5.11.0-1.26425.128 (C# 13.0)
Version: 13.0
Expected: run
Stdout: OK 4
Mutate: Pick.Element(["granite"])
Into: Pick.Element((ReadOnlySpan<object>)new object[]{"granite"})
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

static class Pick{
    public static int Element(ReadOnlySpan<string> x)=>1;public static int Element(ReadOnlySpan<object> x)=>2;
    public static int Type(List<int> x)=>1;public static int Type(IEnumerable<int> x)=>2;
    public static int Readonly(ReadOnlySpan<int> x)=>1;public static int Readonly(Span<int> x)=>2;
    public static int Array(Span<int> x)=>1;public static int Array(int[] x)=>2;
}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Pick.Element(["granite"])==1, "P13-collection13-element-pilot-200001-check-01");
        Check(Pick.Type([239,241])==1, "P13-collection13-element-pilot-200001-check-02");
        Check(Pick.Readonly([251,257])==1, "P13-collection13-element-pilot-200001-check-03");
        Check(Pick.Array([263,269])==1, "P13-collection13-element-pilot-200001-check-04");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
