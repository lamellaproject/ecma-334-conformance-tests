/*
Rules: E12-20-3-1-translation-before-binding; E12-20-3-1-regular-invocation-processing
Authority: ECMA-334 7th ed 12.20.3.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: select item + 1
Into: select "tag"
*/
using System;
delegate int Numeric(int item);
delegate string Textual(int item);
class Source
{
    public int Select(Numeric selector) { Program.trace += "N"; return selector(5); }
    public string Select(Textual selector) { Program.trace += "T"; return selector(5); }
}
class Program
{
    public static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var query = from item in new Source() select item + 1;
        var ordinary = new Source().Select(item => item + 1);
        Check(query == 6 && query == ordinary, "return-type-overload-selection");
        Check(trace == "NN", "ordinary-binding-after-translation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
