/*
Rules: E12-8-12-ed4-inherited-indexer-selection
Authority: ECMA-334 4th ed 14.5.6.2
Version: ISO-2
Expected: run
Stdout: OK 2
Version-Witness: version-witnesses/E12-8-12-ed4-inherited-indexer-selection/inherited-best-indexer.cs.part
Mutate: int observed = value["elm"];
Into: int observed = value[(object)"elm"];
*/
// ECMA-334 4th ed 14.5.6.2, p. 174 (PDF p. 196).
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    interface IWide { int this[object key] { get; } }
    interface INarrow { int this[string key] { get; } }
    interface ICombined : IWide, INarrow { }
    class Lookup : ICombined
    {
        int IWide.this[object key] { get { return 11; } }
        int INarrow.this[string key] { get { return 37; } }
    }
    static int Main()
    {
        ICombined value = new Lookup();
        int observed = value["elm"];
        Check(observed == 37, "inherited-best-indexer");
        Check(((IWide)value)["elm"] == 11, "wide-indexer-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
