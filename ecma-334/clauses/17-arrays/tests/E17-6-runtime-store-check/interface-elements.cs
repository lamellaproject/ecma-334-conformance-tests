/*
Rules: E17-6-runtime-store-check; E10-3-5-compatible; E12-12-12-1-reference-conversion
Authority: ECMA-334 7th ed 17.6
Version: 7.3
Expected: run
Stdout: OK 6
Fixture: {"arguments":["value"]}
Mutate: slots[index] = value;
Into: slots[index] = new Direct(0);
*/
using System;
interface IReading { int Read(); }
interface IChild : IReading { }
interface IMarker { }
class Direct : IReading
{
    int number;
    public Direct(int value) { number = value; }
    public int Read() { return number; }
}
class Inherited : Direct
{
    public Inherited(int value) : base(value) { }
}
class ThroughInterface : IChild
{
    int number;
    public ThroughInterface(int value) { number = value; }
    public int Read() { return number; }
}
struct Reading : IReading
{
    int number;
    public Reading(int value) { number = value; }
    public int Read() { return number; }
}
class Marked : IMarker { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Store(IReading[] slots, int index, IReading value)
    {
        slots[index] = value;
        return slots[index].Read();
    }
    static void StoreMarker(IMarker[] slots, object incoming)
    {
        Check(incoming is IMarker, "empty-interface-type-check");
        IMarker value = (IMarker)incoming;
        slots[0] = value;
        Check((object)slots[0] == (object)value, "empty-interface-element");
    }
    static void Main(string[] arguments)
    {
        int offset = arguments.Length;
        IReading[] slots = new IReading[4];
        Check(Store(slots, 0, new Direct(18 + offset)) == 19, "direct-implementer");
        Direct inherited = new Inherited(22 + offset);
        Check(Store(slots, 1, inherited) == 23, "base-class-implementation");
        IChild child = new ThroughInterface(30 + offset);
        Check(Store(slots, 2, child) == 31, "inherited-interface-implementation");
        Reading reading = new Reading(42 + offset);
        Check(Store(slots, 3, reading) == 43, "boxed-value-implementation");
        object marker = offset == 1 ? (object)new Marked() : new object();
        StoreMarker(new IMarker[1], marker);
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
