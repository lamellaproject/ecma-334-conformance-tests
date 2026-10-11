/*
Rules: P12-inline-standard; P12-inline-span; P12-inline-spread
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: run
Stdout: OK 2
Mutate: Span<int> writable=buffer;
Into: Span<int> writable=new int[3];
*/
using System;

[System.Runtime.CompilerServices.InlineArray(3)] struct Buffer {private int first;} static class Reader{public static int Sum(ReadOnlySpan<int> s)=>s[0]+s[1]+s[2];}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Buffer buffer=default; buffer[0]=223;buffer[1]=227;buffer[2]=229;
        Span<int> writable=buffer; writable[1]=233; ReadOnlySpan<int> read=buffer;
        int[] copied=[..buffer]; Check(buffer[1]==233 && read[2]==229 && copied[0]==223 && copied[1]==233, "P12-inline-standard-pilot-200001-check-01");
        int total=Reader.Sum(buffer); Check(total==685, "P12-inline-standard-pilot-200001-check-02");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
