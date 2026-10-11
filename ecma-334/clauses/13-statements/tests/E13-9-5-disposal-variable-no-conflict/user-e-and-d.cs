/*
Rules: E13-9-5-disposal-variable-no-conflict; E13-9-5-enumerator-variable-hidden
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: foreach (int item in Make(e))
Into: foreach (int item in Make(d))
*/
using System;
class Program
{
    static int checks, failures, disposed;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    struct Cursor : IDisposable
    {
        public int Number;
        int position;
        public int Current { get { return Number; } }
        public bool MoveNext() { return ++position == 1; }
        public void Dispose() { disposed++; }
    }
    class Source
    {
        public int Number;
        public Cursor GetEnumerator() { return new Cursor { Number = Number }; }
    }
    static Source Make(int value) { return new Source { Number = value }; }
    static void Main()
    {
        int e = 7, d = 11, total = 0;
        foreach (int item in Make(e)) { total += item + d; }
        Check(total == 18, "user-variables-remain-visible");
        Check(e == 7 && d == 11, "user-variables-unchanged");
        Check(disposed == 1, "disposal-with-user-d-in-scope");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
