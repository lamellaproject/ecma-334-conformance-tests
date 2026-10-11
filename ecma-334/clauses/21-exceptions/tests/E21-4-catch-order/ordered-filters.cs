/*
Rules: E21-4-catch-order
Authority: ECMA-334 7th ed 21.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: when (Choose(1))
Into: when (Choose(2))
*/
using System;
class Program
{
    static int checks, failures, trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Choose(int tag) { trace = trace * 10 + tag; return tag == 2; }
    static void Main()
    {
        int selected = 0;
        try { throw new Exception(); }
        catch (Exception) when (Choose(1)) { selected = 1; }
        catch (Exception) when (Choose(2)) { selected = 2; }
        catch (Exception) { selected = 3; }
        Check(trace == 12, "filters-considered-in-declaration-order");
        Check(selected == 2, "first-matching-clause-selected");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
