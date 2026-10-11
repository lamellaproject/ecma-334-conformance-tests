/*
Rules: P12-collection-disposal
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: run
Stdout: OK 2
Mutate: int[] values=[..new Source()];
Into: int[] values=default(int[]);
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

class Source:IEnumerable<int>{public static int Disposals;public IEnumerator<int> GetEnumerator()=>new Cursor();IEnumerator IEnumerable.GetEnumerator()=>GetEnumerator();}
class Cursor:IEnumerator<int>{int state;public int Current=>181;object IEnumerator.Current=>Current;public bool MoveNext(){if(++state==1)return true;throw new InvalidOperationException();}public void Reset()=>throw new NotSupportedException();public void Dispose(){Source.Disposals++;}}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        try {int[] values=[..new Source()];Check(false, "P12-collection-disposal-pilot-200001-check-01");}catch (InvalidOperationException) { Check(true, "P12-collection-disposal-pilot-200001-check-01"); } catch (Exception error) { Check(false, "P12-collection-disposal-unexpected-exception-1"); Console.WriteLine("EXCEPTION " + error.GetType().FullName); } Check(Source.Disposals==1, "P12-collection-disposal-pilot-200001-check-02");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
