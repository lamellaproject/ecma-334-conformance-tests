/*
Rules: P15-collection15-first
Authority: csc 5.11.0-1.26425.128 (C# 15.0)
Version: 15.0
Expected: reject
Mutate: Bag bag=[631,with(641)];
Into: Bag bag=default(Bag);
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

class Bag:IEnumerable<int>{public int Tag;public List<int> Values=new List<int>();public Bag(int tag){Tag=tag;}public void Add(int n)=>Values.Add(n);public IEnumerator<int> GetEnumerator()=>Values.GetEnumerator();IEnumerator IEnumerable.GetEnumerator()=>GetEnumerator();}
class VariadicBag:IEnumerable<int>{public int Tag;public VariadicBag(params int[] args){Tag=args[0]+args[1];}public void Add(int n){Tag+=n;}public IEnumerator<int> GetEnumerator(){yield return Tag;}IEnumerator IEnumerable.GetEnumerator()=>GetEnumerator();}
static class Events{public static string Log="";public static int Read(int n){Log+=n+";";return n;}}

class Program
{
    static void Main()
    {
        Bag bag=[631,with(641)];
    }
}
