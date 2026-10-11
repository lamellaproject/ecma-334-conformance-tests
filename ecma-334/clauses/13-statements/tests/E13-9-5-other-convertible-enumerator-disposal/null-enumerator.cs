/*
Rules: E13-9-5-other-convertible-enumerator-disposal; E13-9-5-other-convertible-enumerator-disposal-conversion
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: foreach (int item in new Source()) { }
Into: Cursor cursor = new Source().GetEnumerator(); try { cursor.MoveNext(); } finally { ((IDisposable)cursor).Dispose(); }
*/
using System;
class Program
{
    static int checks, failures, filters;
    static Exception first;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Remember(Exception exception) { filters++; if (first == null) first = exception; return true; }
    class Source { public Cursor GetEnumerator() { return null; } }
    class Cursor : IDisposable
    {
        public int Current { get { return 0; } }
        public bool MoveNext() { return false; }
        public void Dispose() { }
    }
    static void Main()
    {
        int caught = 0;
        bool same = false;
        try { foreach (int item in new Source()) { } }
        catch (NullReferenceException exception) when (Remember(exception)) { caught = 1; same = object.ReferenceEquals(first, exception); }
        catch (Exception) { caught = 2; }
        Check(caught == 1, "null-movenext-throws-nullreference");
        // The filter sees the first exception before finally; disposal must not replace it.
        Check(filters == 1 && same, "null-disposal-skipped-without-replacement-exception");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
