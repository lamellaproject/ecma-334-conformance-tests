/*
Rules: E13-9-5-getenumerator-overload-resolution; E13-9-5-movenext-overload-resolution
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public Cursor GetEnumerator() { selected++; return new Cursor(); }
Into: public Cursor GetEnumerator(bool ignored) { selected++; return new Cursor(); }
*/
using System;
class Program
{
    static int checks, failures, selected, wrong;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    class Source
    {
        public Cursor GetEnumerator() { selected++; return new Cursor(); }
        public Cursor GetEnumerator(int ignored = 0) { wrong++; return new Cursor(); }
        public Cursor GetEnumerator<T>() { wrong++; return new Cursor(); }
    }
    class Cursor
    {
        int position;
        public int Current { get { return 14; } }
        public bool MoveNext() { selected++; return ++position == 1; }
        public bool MoveNext(int ignored = 0) { wrong++; return false; }
        public bool MoveNext<T>() { wrong++; return false; }
    }
    static void Main()
    {
        int total = 0;
        foreach (int item in new Source()) { total += item; }
        Check(total == 14, "empty-list-enumerates");
        Check(selected == 3 && wrong == 0, "parameterless-overloads-win");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
