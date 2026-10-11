/*
Rules: P14-span14-no-methodgroup
Authority: csc 5.11.0-1.26425.128 (C# 14.0)
Version: 14.0
Expected: reject
Mutate: Func<int> group=source.Total;
Into: Func<int> group=default(Func<int>);
*/
using System;

static class SpanExtensions{public static int Total(this ReadOnlySpan<int> source)=>source.Length;}
class Program
{
    static void Main()
    {
        int[] source=new int[]{499};Func<int> group=source.Total;
    }
}
