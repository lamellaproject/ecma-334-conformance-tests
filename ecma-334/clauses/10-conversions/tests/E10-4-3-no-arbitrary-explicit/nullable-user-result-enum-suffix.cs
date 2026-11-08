/*
Rules: E10-4-3-no-arbitrary-explicit; E10-5-5-empty
Authority: ECMA-334 7th ed 10.4.3
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/E10-4-3-no-arbitrary-explicit/nullable-user-result-enum-suffix.cs.part
Mutate: (Signal)source
Into: (Signal)(int)source
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    enum Signal { Marked = 37 }
    struct Measure
    {
        public static explicit operator int(Measure? item) { return item.HasValue ? 37 : 19; }
    }
    static int Main()
    {
        Measure? source = new Measure();
        Signal result = (Signal)source;
        Check(result == Signal.Marked, "separate-user-and-enum-cast-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
