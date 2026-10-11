/*
Rules: E15-2-4-1-grammar-class-base-form-3; E15-2-4-1-grammar-interface-type-list; E15-2-4-3-implements-listed-interfaces
Authority: ECMA-334 7th ed 15.2.4.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: class Gauge : Root, IReading, IReset
Into: class Gauge : Root, IReset
*/
using System;
interface IReading { int Read(); }
interface IReset { int Reset(); }
class Root { public int Bias = 5; }
class Gauge : Root, IReading, IReset
{
    public int Read() { return Bias + 199; }
    public int Reset() { return 211; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge gauge = new Gauge();
        Root root = gauge;
        IReading reading = gauge;
        IReset reset = gauge;
        Check(root == gauge, "class-first-in-base-list");
        Check(reading.Read() == 204, "first-interface-in-list");
        Check(reset.Reset() == 211, "following-interface-in-list");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
