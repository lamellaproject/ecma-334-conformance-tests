/*
Rules: E12-17-underscore-discard; E12-17-discard-no-name; E12-17-simple-discard-equivalence
Authority: ECMA-334 7th ed 12.17
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: out int _
Into: out int occupied
*/
using System;
class Program
{
    static string trace = "";
    static void Fill(out int value) { trace += "I"; value = 41; }
    static void FillFlag(out bool value) { trace += "B"; value = true; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Fill(out int _); FillFlag(out var _);
        string _ = "kept"; int occupied = 3;
        Check(_ == "kept" && occupied == 3 && trace == "IB", "typed-and-inferred-discards-introduce-no-name");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
