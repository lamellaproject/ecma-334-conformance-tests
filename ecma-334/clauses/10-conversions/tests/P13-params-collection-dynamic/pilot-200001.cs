/*
Rules: P13-params-collection-dynamic
Authority: csc 5.11.0-1.26425.128 (C# 13.0)
Version: 13.0
Expected: reject
Mutate: dynamic n=439;
Into: int n=439;
*/
using System;

static class Params{public static int Sum(params ReadOnlySpan<int> x)=>x.Length;}
class Program
{
    static void Main()
    {
        dynamic n=439; Params.Sum(n,443);
    }
}
