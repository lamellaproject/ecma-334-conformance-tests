/*
Rules: E13-9-5-sealed-nondisposable-enumerator
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: sealed class Cursor
Into: sealed class Cursor : IDisposable
*/
using System;
class Program
{
    static int checks, failures, disposed;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    class Source { public Cursor GetEnumerator() { return new Cursor(); } }
    sealed class Cursor
    {
        int position;
        public int Current { get { return 31; } }
        public bool MoveNext() { return ++position == 1; }
        public void Dispose() { disposed++; }
    }
    static void Main()
    {
        int total = 0;
        foreach (int item in new Source()) { total += item; }
        Check(total == 31, "sealed-enumerator-yields");
        Check(disposed == 0, "sealed-nondisposable-has-empty-finally");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
