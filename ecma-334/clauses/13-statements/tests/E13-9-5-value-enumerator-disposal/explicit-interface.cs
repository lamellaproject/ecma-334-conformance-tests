/*
Rules: E13-9-5-value-enumerator-disposal
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: foreach (int item in new Source()) { total += item; }
Into: Cursor cursor = new Source().GetEnumerator(); while (cursor.MoveNext()) { total += cursor.Current; }
*/
using System;
class Program
{
    static int checks, failures, disposed;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    class Source { public Cursor GetEnumerator() { return new Cursor(); } }
    struct Cursor : IDisposable
    {
        int position;
        public int Current { get { return 15; } }
        public bool MoveNext() { return ++position == 1; }
        void IDisposable.Dispose() { disposed++; }
        public void Dispose() { throw new Exception(); }
    }
    static void Main()
    {
        int total = 0;
        foreach (int item in new Source()) { total += item; }
        Check(total == 15, "value-enumerator-yields-element");
        Check(disposed == 1, "disposal-uses-idisposable-not-public-pattern");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
