/*
Rules: E12-8-16-5-dimension-exception
Authority: ECMA-334 7th ed 12.8.16.5
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: new int[Read("A", true), Read("B", false)]
Into: new int[Read("A", false), Read("B", false)]
*/
using System;
class Marker : Exception { }
class Program
{
    static string trace = "";
    static int Read(string tag, bool stop) { trace += tag; if (stop) throw new Marker(); return 2; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[,] old = new int[1, 1];
        int[,] cells = old;
        bool caught = false;
        try { cells = new int[Read("A", true), Read("B", false)]; }
        catch (Marker) { caught = true; }
        catch (Exception) { }
        Check(caught, "dimension-expression-exception");
        Check(trace == "A", "later-dimension-not-evaluated");
        Check(object.ReferenceEquals(cells, old), "failed-dimension-no-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
