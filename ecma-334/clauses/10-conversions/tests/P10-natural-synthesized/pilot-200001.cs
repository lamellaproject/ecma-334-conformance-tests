/*
Rules: P10-natural-synthesized; P10-natural-reuse
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 1
Mutate: int input=263;
Into: int input=default(int);
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var first=(ref int x)=>{x+=67;}; var second=(ref int x)=>{x+=71;}; int input=263; first(ref input); second(ref input); Check(input==401 && first.GetType()==second.GetType(), "P10-natural-synthesized-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
