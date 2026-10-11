/*
Rules: E22-5-3-2-conditional-method-definition; E22-5-1-conditional-multi-use; E22-5-3-1-conditional-methods; E22-5-3-2-conditional-method-symbols; E22-5-3-2-conditional-call-include; E22-5-3-2-conditional-call-omit
Authority: ECMA-334 7th ed 22.5.3.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: [System.Diagnostics.Conditional("ABSENT")]
Into: [System.Diagnostics.Conditional("PRESENT")]
*/
#define PRESENT
using System;
class Calls
{
    public static int Evaluations, Hits;
    public static int Argument() { Evaluations++; return 7; }
    [System.Diagnostics.Conditional("PRESENT"), System.Diagnostics.Conditional("ALSO_ABSENT")]
    public static void Included(int value) { Hits += value; }
    [System.Diagnostics.Conditional("ABSENT")]
    public static void Omitted(int value) { Hits += value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Calls.Included(Calls.Argument());
        Calls.Omitted(Calls.Argument());
        Check(Calls.Evaluations == 1, "omitted-argument-not-evaluated");
        Check(Calls.Hits == 7, "one-defined-symbol-includes-call");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
