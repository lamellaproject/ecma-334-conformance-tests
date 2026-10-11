/*
Rules: P15-collection15-last-parameter
Authority: csc 5.11.0-1.26425.128 (C# 15.0)
Version: 15.0
Expected: reject
Mutate: Store<int> value=[with(691),701];
Into: Store<int> value=default(Store<int>);
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[CollectionBuilder(typeof(Builder),"Make")]
class Store<T>:IEnumerable<T>{public int Tag;public T[] Items;public Store(int tag,T[] values){Tag=tag;Items=values;}public IEnumerator<T> GetEnumerator()=>((IEnumerable<T>)Items).GetEnumerator();IEnumerator IEnumerable.GetEnumerator()=>GetEnumerator();}
static class Builder{
    public static Store<T> Make<T>(ReadOnlySpan<T> values,int tag)=>new Store<T>(tag,values.ToArray());
    public static Store<T> Make<T>(ReadOnlySpan<T> values,string tag)=>new Store<T>(tag.Length,values.ToArray());
}

class Program
{
    static void Main()
    {
        Store<int> value=[with(691),701];
    }
}
