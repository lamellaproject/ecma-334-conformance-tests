/*
Rules: E12-20-3-1-execution-unspecified; E12-20-3-1-methods-execute
Authority: ECMA-334 7th ed 12.20.3.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: from item in source where item < 0 select item + 30
Into: from item in source select item + 30
*/
using System;
delegate R Evaluate<T, R>(T item);
class Signal
{
    public Signal Where(Evaluate<int, bool> predicate) { Program.trace += "W"; return this; }
    public int Select(Evaluate<int, int> selector) { Program.trace += "S"; return 92; }
}
class Program
{
    public static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var source = new Signal();
        // These methods intentionally ignore both callbacks; the language imposes no execution algorithm.
        int result = from item in source where item < 0 select item + 30;
        Check(result == 92, "custom-execution-result");
        Check(trace == "WS", "methods-own-callback-policy");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
