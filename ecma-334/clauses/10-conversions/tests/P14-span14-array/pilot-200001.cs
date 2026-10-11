/*
Rules: P14-span14-array; P14-span14-array-readonly; P14-span14-mutable-readonly; P14-span14-covariant; P14-span14-string; P14-span14-extension
Authority: csc 5.11.0-1.26425.128 (C# 14.0)
Version: 14.0
Expected: run
Stdout: OK 2
Mutate: ReadOnlySpan<char> chars="quartz";
Into: ReadOnlySpan<char> chars="";
*/
using System;

static class SpanExtensions{public static int Total<T>(this ReadOnlySpan<T> values)=>values.Length;}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string[] values=new string[]{"slate","shale"}; Span<string> mutable=values;
        ReadOnlySpan<string> same=mutable; ReadOnlySpan<object> fromArray=values;
        ReadOnlySpan<object> fromMutable=mutable; ReadOnlySpan<object> fromReadonly=same;
        ReadOnlySpan<char> chars="quartz";
        mutable[1]="schist";
        Check((string)fromArray[0]=="slate" && (string)fromMutable[1]=="schist" && (string)fromReadonly[1]=="schist", "P14-span14-array-pilot-200001-check-01");
        Check(chars.Length==6 && chars[0]=='q' && values.Total()==2, "P14-span14-array-pilot-200001-check-02");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
