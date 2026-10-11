/*
Rules: E13-9-5-type-parameter-disposal-no-boxing
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: foreach (int item in source) { }
Into: E cursor = source.GetEnumerator(); cursor.MoveNext(); ((IDisposable)cursor).Dispose();
*/
using System;
using System.Collections;
using System.Collections.Generic;
class Program
{
    static int checks, failures, disposed;
    static bool same;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    class Source<E> where E : struct, IEnumerator<int> { public E GetEnumerator() { return default(E); } }
    // Only the storage comparison needs clause 23 unsafe pointers.
    unsafe struct Cursor : IEnumerator<int>
    {
        int marker;
        ulong address;
        public int Current { get { return 0; } }
        object IEnumerator.Current { get { return 0; } }
        public bool MoveNext() { fixed (int* pointer = &marker) { address = (ulong)pointer; } return false; }
        public void Reset() { }
        public void Dispose() { disposed++; fixed (int* pointer = &marker) { same = address == (ulong)pointer; } }
    }
    static void Enumerate<E>(Source<E> source) where E : struct, IEnumerator<int>
    {
        foreach (int item in source) { }
    }
    static void Main()
    {
        Enumerate(new Source<Cursor>());
        Check(disposed == 1, "type-parameter-value-enumerator-disposed");
        // Compare storage, without reading through a saved pointer, to observe boxing's copy.
        Check(same, "constrained-disposal-does-not-box-enumerator");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
