/*
Rules: E13-9-5-getenumerator-overload-resolution
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: run
Stdout: OK 2
Version-Witness: version-witnesses/optional-argument-9d35a5dcce.cs.part
Mutate: public Cursor GetEnumerator(int value = 37) { return new Cursor { Number = value }; }
Into: public Cursor GetEnumerator() { return new Cursor { Number = 0 }; }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    class Source
    {
        public Cursor GetEnumerator(int value = 37) { return new Cursor { Number = value }; }
    }
    class Cursor
    {
        public int Number;
        int position;
        public int Current { get { return Number; } }
        public bool MoveNext() { return ++position == 1; }
    }
    static void Main()
    {
        int total = 0, visits = 0;
        foreach (int item in new Source()) { total += item; visits++; }
        Check(total == 37, "getenumerator-optional-argument-default");
        Check(visits == 1, "optional-getenumerator-is-applicable-to-empty-list");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
