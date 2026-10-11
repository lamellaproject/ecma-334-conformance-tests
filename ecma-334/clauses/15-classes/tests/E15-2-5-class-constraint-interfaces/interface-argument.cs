/*
Rules: E15-2-5-class-constraint-interfaces
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where T : class
Into: where T : struct
*/
using System;
interface IReading { int Read(); }
class Record : IReading { public int Read() { return 127; } }
class Program
{
    static T Echo<T>(T value) where T : class { return value; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IReading item = new Record();
        Check(Echo<IReading>(item) == item, "interface-type-satisfies-reference-constraint");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
