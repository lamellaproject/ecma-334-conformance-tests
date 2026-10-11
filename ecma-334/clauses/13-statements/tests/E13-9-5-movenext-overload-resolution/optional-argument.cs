/*
Rules: E13-9-5-movenext-overload-resolution
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: run
Stdout: OK 2
Version-Witness: version-witnesses/optional-argument-3f321b9623.cs.part
Mutate: public bool MoveNext(int limit = 1) { return ++position <= limit; }
Into: public bool MoveNext() { return false; }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    class Source { public Cursor GetEnumerator() { return new Cursor(); } }
    class Cursor
    {
        int position;
        public int Current { get { return 41; } }
        public bool MoveNext(int limit = 1) { return ++position <= limit; }
    }
    static void Main()
    {
        int total = 0, visits = 0;
        foreach (int item in new Source()) { total += item; visits++; }
        Check(total == 41, "movenext-optional-argument-default");
        Check(visits == 1, "optional-movenext-is-applicable-to-empty-list");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
