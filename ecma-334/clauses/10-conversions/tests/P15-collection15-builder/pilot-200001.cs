/*
Rules: P15-collection15-builder
Authority: csc 5.11.0-1.26425.128 (C# 15.0)
Version: 15.0
Expected: run
Stdout: OK 1
Mutate: Store<long> numeric=[with(661),673,677];
Into: Store<long> numeric=default(Store<long>);
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[CollectionBuilder(typeof(Builder),"Make")]
class Store<T>:IEnumerable<T>{public int Tag;public T[] Items;public Store(int tag,T[] values){Tag=tag;Items=values;}public IEnumerator<T> GetEnumerator()=>((IEnumerable<T>)Items).GetEnumerator();IEnumerator IEnumerable.GetEnumerator()=>GetEnumerator();}
static class Builder{
    public static Store<T> Make<T>(int tag,ReadOnlySpan<T> values)=>new Store<T>(tag,values.ToArray());
    public static Store<T> Make<T>(string tag,ReadOnlySpan<T> values)=>new Store<T>(tag.Length,values.ToArray());
}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Store<long> numeric=[with(661),673,677];Store<long> textual=[with("chert"),683];Check(numeric.Tag==661 && numeric.Items[1]==677 && textual.Tag==5 && textual.Items[0]==683, "P15-collection15-builder-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
