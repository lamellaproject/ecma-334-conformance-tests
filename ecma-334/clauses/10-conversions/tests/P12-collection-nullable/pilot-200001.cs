/*
Rules: P12-collection-nullable; P12-collection-constructor
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: run
Stdout: OK 1
Mutate: Bag? wrapped=[103,107];
Into: Bag? wrapped=default(Bag?);
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

struct Bag:IEnumerable<int>{public List<int> Data;public Bag(){Data=new List<int>();}public void Add(int x)=>Data.Add(x);public IEnumerator<int> GetEnumerator()=>Data.GetEnumerator();IEnumerator IEnumerable.GetEnumerator()=>GetEnumerator();}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Bag? wrapped=[103,107]; Check(wrapped.HasValue && wrapped.Value.Data[1]==107, "P12-collection-nullable-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
