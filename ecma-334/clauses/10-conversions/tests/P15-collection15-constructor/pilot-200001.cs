/*
Rules: P15-collection15-constructor; P15-collection15-params; P15-collection15-order; P15-collection15-interfaces
Authority: csc 5.11.0-1.26425.128 (C# 15.0)
Version: 15.0
Expected: run
Stdout: OK 2
Mutate: Bag bag=[with(Events.Read(563)),Events.Read(569),Events.Read(571)];
Into: Bag bag=new Bag(563);
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
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Bag bag=[with(Events.Read(563)),Events.Read(569),Events.Read(571)];
        VariadicBag variadic=[with(577,587),593];
        IList<int> mutable=[with(19),599,601];ICollection<int> collection=[with(),607];
        IReadOnlyList<int> readonly_=[with(),613];IEnumerable<int> sequence=[with(),617];
        Check(bag.Tag==563 && bag.Values[0]==569 && bag.Values[1]==571 && Events.Log=="563;569;571;", "P15-collection15-constructor-pilot-200001-check-01");
        Check(variadic.Tag==1757 && mutable[1]==601 && collection.Count==1 && readonly_[0]==613 && new List<int>(sequence)[0]==617, "P15-collection15-constructor-pilot-200001-check-02");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
