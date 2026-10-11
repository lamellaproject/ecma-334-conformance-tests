/*
Rules: E15-2-4-3-partial-interface-union; E15-2-4-3-interface-repeat-across-parts; E15-2-4-3-interface-implementation-other-part
Authority: ECMA-334 7th ed 15.2.4.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: partial class Gauge : IReading, IReset
Into: partial class Gauge : IReading
*/
using System;
interface IReading { int Read(); }
interface IReset { int Reset(); }
partial class Gauge : IReading { public int Reset() { return 257; } }
partial class Gauge : IReading, IReset { public int Read() { return 263; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge gauge = new Gauge();
        IReading reading = gauge;
        IReset reset = gauge;
        Check(reading.Read() == 263, "partial-interface-repeated-across-parts");
        Check(reset.Reset() == 257, "partial-interface-union-implementation-in-other-part");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
