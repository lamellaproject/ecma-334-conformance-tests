/*
Rules: P12-collection-builder-boxing
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: run
Stdout: OK 1
Mutate: IBox result=[137,139];
Into: IBox result=default(IBox);
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[CollectionBuilder(typeof(Builder),"Make")] interface IBox:IEnumerable<int>{int Sum{get;}}
struct ValueBox:IBox{public int Sum{get;set;}public IEnumerator<int> GetEnumerator(){yield return Sum;}IEnumerator IEnumerable.GetEnumerator()=>GetEnumerator();}
static class Builder{public static ValueBox Make(ReadOnlySpan<int> x)=>new ValueBox{Sum=x[0]+x[1]};}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IBox result=[137,139]; Check(result is ValueBox && result.Sum==276, "P12-collection-builder-boxing-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
