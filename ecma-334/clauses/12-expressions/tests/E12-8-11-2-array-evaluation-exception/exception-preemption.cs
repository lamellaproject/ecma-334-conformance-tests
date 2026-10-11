/*
Rules: E12-8-11-2-array-evaluation-exception; E12-8-11-2-index-exception; E12-8-11-2-array-null
Authority: ECMA-334 7th ed 12.8.11.2
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Fetch(1)[Index(false), Later()]
Into: Fetch(0)[Index(false), Later()]
*/
using System;
class Marker : Exception { }
struct Offset { public bool fail; public static implicit operator int(Offset value) { Program.trace += "C"; if (value.fail) throw new Marker(); return 0; } }
class Program
{
    public static string trace = "";
    static int checks, failures;
    static int[,] Fetch(int mode) { trace += "P"; if (mode == 1) throw new Marker(); return mode == 2 ? null : new int[1, 1]; }
    static Offset Index(bool fail) { trace += "A"; return new Offset { fail = fail }; }
    static int ThrowIndex() { trace += "A"; throw new Marker(); }
    static int Later() { trace += "B"; return 0; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool caught = false;
        try { int result = Fetch(1)[Index(false), Later()]; } catch (Marker) { caught = true; } catch (Exception) { }
        Check(caught && trace == "P", "receiver-exception-skips-all-indices");
        trace = ""; caught = false;
        try { int result = Fetch(2)[ThrowIndex(), Later()]; } catch (Marker) { caught = true; } catch (Exception) { }
        Check(caught && trace == "PA", "index-expression-exception-preempts-next-index-and-null-check");
        trace = ""; caught = false;
        try { int result = Fetch(2)[Index(true), Later()]; } catch (Marker) { caught = true; } catch (Exception) { }
        Check(caught && trace == "PAC", "conversion-exception-preempts-next-index-and-null-check");
        trace = ""; caught = false;
        try { int result = Fetch(2)[Index(false), Later()]; } catch (NullReferenceException) { caught = true; } catch (Exception) { }
        Check(caught && trace == "PACB", "null-array-check-follows-all-indices-and-conversions");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
