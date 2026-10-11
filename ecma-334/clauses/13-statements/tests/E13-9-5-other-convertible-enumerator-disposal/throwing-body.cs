/*
Rules: E13-9-5-other-convertible-enumerator-disposal; E13-9-5-other-convertible-enumerator-disposal-conversion; E13-9-5-foreach-disposal-finally
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: foreach (int item in new Source()) { trace += "B"; throw marker; }
Into: Cursor cursor = new Source().GetEnumerator(); if (cursor.MoveNext()) { trace += "B"; throw marker; }
*/
using System;
class Program
{
    static int checks, failures;
    static string trace = "";
    static Exception marker = new Exception();
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    class Source { public Cursor GetEnumerator() { trace += "G"; return new Cursor(); } }
    class Cursor : IDisposable
    {
        public int Current { get { trace += "C"; return 1; } }
        public bool MoveNext() { trace += "M"; return true; }
        void IDisposable.Dispose() { trace += "D"; }
        public void Dispose() { throw new Exception(); }
    }
    static void Main()
    {
        bool same = false;
        try { foreach (int item in new Source()) { trace += "B"; throw marker; } }
        catch (Exception caught) { same = object.ReferenceEquals(caught, marker); trace += "H"; }
        Check(same, "body-exception-identity-preserved");
        Check(trace == "GMCBDH", "reference-interface-disposal-before-handler");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
