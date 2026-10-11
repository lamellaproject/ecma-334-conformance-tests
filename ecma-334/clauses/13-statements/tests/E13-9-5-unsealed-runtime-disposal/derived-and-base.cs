/*
Rules: E13-9-5-unsealed-runtime-disposal; E13-9-5-unsealed-runtime-disposal-conversion
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: foreach (int item in new Source(true)) { total += item; break; }
Into: Cursor cursor = new Source(true).GetEnumerator(); if (cursor.MoveNext()) { total += cursor.Current; }
*/
using System;
class Program
{
    static int checks, failures, disposed, patternCalls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    class Source
    {
        bool derived;
        public Source(bool value) { derived = value; }
        public Cursor GetEnumerator() { return derived ? new DisposableCursor() : new Cursor(); }
    }
    class Cursor
    {
        int position;
        public int Current { get { return 16; } }
        public bool MoveNext() { return ++position <= 2; }
        public void Dispose() { patternCalls++; }
    }
    class DisposableCursor : Cursor, IDisposable { void IDisposable.Dispose() { disposed++; } }
    static void Main()
    {
        int total = 0;
        foreach (int item in new Source(true)) { total += item; break; }
        Check(total == 16 && disposed == 1, "runtime-disposable-derived-enumerator");
        total = 0;
        foreach (int item in new Source(false)) { total += item; }
        Check(total == 32, "nondisposable-base-enumeration");
        Check(disposed == 1, "null-interface-result-skips-disposal");
        Check(patternCalls == 0, "public-dispose-pattern-is-ignored");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
