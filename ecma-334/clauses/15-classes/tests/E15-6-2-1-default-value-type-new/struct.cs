/*
Rules: E15-6-2-1-default-value-type-new
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Stamp value = new Stamp()
Into: Stamp value = new Stamp(17)
*/
using System;
struct Stamp
{
    public int Value;
    public Stamp(int value) { Value = value; }
}
class Program
{
    static int Read(Stamp value = new Stamp()) { return value.Value; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Read() == 0, "new-value-type-default-argument");
        Check(Read(new Stamp(19)) == 19, "supplied-value-type-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
