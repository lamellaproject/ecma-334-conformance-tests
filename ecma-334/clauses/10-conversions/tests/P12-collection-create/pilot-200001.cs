/*
Rules: P12-collection-create; P12-collection-builder-generic
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: run
Stdout: OK 1
Mutate: Stored<long> value=[109,113];
Into: Stored<long> value=default(Stored<long>);
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[CollectionBuilder(typeof(Builder),"Make")]
class Stored<T>:IEnumerable<T>{public T[] Values;public Stored(T[] x){Values=x;}public IEnumerator<T> GetEnumerator()=>((IEnumerable<T>)Values).GetEnumerator();IEnumerator IEnumerable.GetEnumerator()=>GetEnumerator();}
static class Builder{public static Stored<T> Make<T>(ReadOnlySpan<T> items)=>new Stored<T>(items.ToArray());}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Stored<long> value=[109,113]; Check(value.Values.Length==2 && value.Values[1]==113L, "P12-collection-create-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
