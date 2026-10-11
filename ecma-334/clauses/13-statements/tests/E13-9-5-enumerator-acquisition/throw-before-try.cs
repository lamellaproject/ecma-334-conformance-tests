/*
Rules: E13-9-5-enumerator-acquisition
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public Cursor GetEnumerator() { throw marker; }
Into: public Cursor GetEnumerator() { return new Cursor(); }
*/
using System;
class Program
{
    static int checks, failures, disposed;
    static Exception marker = new Exception();
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    class Source { public Cursor GetEnumerator() { throw marker; } }
    struct Cursor : IDisposable
    {
        public int Current { get { return 0; } }
        public bool MoveNext() { return false; }
        public void Dispose() { disposed++; }
    }
    static void Main()
    {
        bool same = false;
        try { foreach (int item in new Source()) { } }
        catch (Exception caught) { same = object.ReferenceEquals(caught, marker); }
        Check(same, "acquisition-exception-propagates");
        Check(disposed == 0, "failed-acquisition-never-enters-disposal-try");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
