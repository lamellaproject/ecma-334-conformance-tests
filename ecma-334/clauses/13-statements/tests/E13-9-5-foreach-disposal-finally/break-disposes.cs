/*
Rules: E13-9-5-foreach-disposal-finally
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: foreach (int item in new Source()) { total += item; break; }
Into: { Cursor cursor = new Source().GetEnumerator(); if (cursor.MoveNext()) total += cursor.Current; }
*/
using System;
class Program
{
    static int checks, failures, disposals;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    class Source
    {
        public Cursor GetEnumerator() { return new Cursor(); }
    }
    struct Cursor : IDisposable
    {
        int moves;
        public int Current { get { return 8; } }
        public bool MoveNext() { moves++; return moves <= 2; }
        public void Dispose() { disposals++; }
    }
    static void Main()
    {
        int total = 0;
        foreach (int item in new Source()) { total += item; break; }
        Check(total == 8, "break-after-first-element");
        Check(disposals == 1, "break-runs-disposal-finally");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
