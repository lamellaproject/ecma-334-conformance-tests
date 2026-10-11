/*
Rules: P12-collection-builder-arity
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: reject
Mutate: Stored<int> result=[149];
Into: Stored<int> result=default(Stored<int>);
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[CollectionBuilder(typeof(Builder),"Make")]
class Stored<T>:IEnumerable<T>{public T[] Values;public Stored(T[] x){Values=x;}public IEnumerator<T> GetEnumerator()=>((IEnumerable<T>)Values).GetEnumerator();IEnumerator IEnumerable.GetEnumerator()=>GetEnumerator();}
class Builder{public static Stored<T> Make<T,U>(ReadOnlySpan<T> items)=>new Stored<T>(items.ToArray());}

class Program
{
    static void Main()
    {
        Stored<int> result=[149];
    }
}
