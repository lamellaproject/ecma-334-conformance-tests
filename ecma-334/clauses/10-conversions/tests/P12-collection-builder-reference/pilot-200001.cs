/*
Rules: P12-collection-builder-reference
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: run
Stdout: OK 1
Mutate: BaseBag result=[127,131];
Into: BaseBag result=default(BaseBag);
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[CollectionBuilder(typeof(Builder),"Make")]
abstract class BaseBag:IEnumerable<int>{public abstract int Sum{get;}public IEnumerator<int> GetEnumerator(){yield return Sum;}IEnumerator IEnumerable.GetEnumerator()=>GetEnumerator();}
class DerivedBag:BaseBag{int sum;public DerivedBag(int x){sum=x;}public override int Sum=>sum;}
static class Builder{public static DerivedBag Make(ReadOnlySpan<int> x)=>new DerivedBag(x[0]+x[1]);}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        BaseBag result=[127,131]; Check(result is DerivedBag && result.Sum==258, "P12-collection-builder-reference-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
