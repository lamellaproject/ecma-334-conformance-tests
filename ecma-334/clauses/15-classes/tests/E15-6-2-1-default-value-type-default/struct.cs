/*
Rules: E15-6-2-1-default-value-type-default
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Stamp value = default(Stamp)
Into: Stamp value = new Stamp(29)
*/
using System;
struct Stamp
{
    public int Value;
    public Stamp(int value) { Value = value; }
}
class Program
{
    static int Read(Stamp value = default(Stamp)) { return value.Value; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Read() == 0, "default-value-type-default-argument");
        Check(Read(new Stamp(31)) == 31, "supplied-argument-overrides-default-value-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
