/*
Rules: P14-span14-standard
Authority: csc 5.11.0-1.26425.128 (C# 14.0)
Version: 14.0
Expected: run
Stdout: OK 1
Mutate: Sum target=source;
Into: Sum target=default(Sum);
*/
using System;

struct Sum{public int Value;public static implicit operator Sum(ReadOnlySpan<int> values)=>new Sum{Value=values[0]+values[1]};}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] source=new int[]{479,487}; Sum target=source;Check(target.Value==966, "P14-span14-standard-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
