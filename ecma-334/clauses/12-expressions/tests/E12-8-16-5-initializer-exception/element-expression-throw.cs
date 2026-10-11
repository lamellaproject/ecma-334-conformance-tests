/*
Rules: E12-8-16-5-initializer-exception; E12-8-16-5-initializer-evaluation
Authority: ECMA-334 7th ed 12.8.16.5
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Read("B", true)
Into: Read("B", false)
*/
using System;
class Marker : Exception { }
class Program
{
    static string trace = "";
    static int Read(string tag, bool stop) { trace += tag; if (stop) throw new Marker(); return 7; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] old = new int[1];
        int[] cells = old;
        bool caught = false;
        try { cells = new int[3] { Read("A", false), Read("B", true), Read("C", false) }; }
        catch (Marker) { caught = true; }
        catch (Exception) { }
        Check(caught, "initializer-expression-exception");
        Check(trace == "AB", "later-initializer-not-evaluated");
        Check(object.ReferenceEquals(cells, old), "failed-initializer-no-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
