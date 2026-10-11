/*
Rules: P14-span14-preference; P14-span14-readonly-preference
Authority: csc 5.11.0-1.26425.128 (C# 14.0)
Version: 14.0
Expected: run
Stdout: OK 1
Mutate: Pick.Read(source)
Into: Pick.Read((object)source)
*/
using System;

static class Pick{public static int Read(ReadOnlySpan<int> x)=>1;public static int Read(object x)=>2;public static int Readonly(ReadOnlySpan<int> x)=>1;public static int Readonly(Span<int> x)=>2;}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] source=new int[]{503};Check(Pick.Read(source)==1 && Pick.Readonly(source)==1, "P14-span14-preference-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
