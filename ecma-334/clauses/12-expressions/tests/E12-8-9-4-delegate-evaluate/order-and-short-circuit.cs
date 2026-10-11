/*
Rules: E12-8-9-4-delegate-evaluate; E12-8-9-4-delegate-evaluation-exception; E12-8-9-4-arguments-evaluate; E12-8-9-4-arguments-exception; E12-8-9-4-delegate-null
Authority: ECMA-334 7th ed 12.8.9.4
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Fetch(0)(Argument(false))
Into: Fetch(2)(Argument(false))
*/
using System;
delegate int Operation(int value);
class Marker : Exception { }
class Program
{
    static int checks, failures;
    static string trace = "";
    static int Work(int value) { trace += "M"; return value + 3; }
    static Operation Fetch(int mode) { trace += "D"; if (mode == 1) throw new Marker(); return mode == 2 ? null : (Operation)Work; }
    static int Argument(bool fail) { trace += "A"; if (fail) throw new Marker(); return 5; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = Fetch(0)(Argument(false));
        Check(value == 8 && trace == "DAM", "delegate-before-arguments-before-call");
        trace = "";
        bool caught = false;
        try { Fetch(1)(Argument(false)); } catch (Marker) { caught = true; } catch (Exception) { }
        Check(caught && trace == "D", "delegate-evaluation-exception-skips-arguments");
        trace = ""; caught = false;
        try { Fetch(2)(Argument(true)); } catch (Marker) { caught = true; } catch (Exception) { }
        Check(caught && trace == "DA", "argument-exception-precedes-null-check");
        trace = ""; caught = false;
        try { Fetch(2)(Argument(false)); } catch (NullReferenceException) { caught = true; } catch (Exception) { }
        Check(caught && trace == "DA", "null-delegate-checked-after-arguments");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
