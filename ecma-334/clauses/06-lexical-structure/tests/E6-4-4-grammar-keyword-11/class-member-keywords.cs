/*
Rules: E6-4-4-grammar-keyword-11; E6-4-4-grammar-keyword-41; E6-4-4-grammar-keyword-48; E6-4-4-grammar-keyword-50; E6-4-4-grammar-keyword-53; E6-4-4-grammar-keyword-63; E6-4-4-grammar-keyword-75
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Beacon
Into: @class Beacon
*/
using System;
class Beacon
{
    private int stored;
    public void Set(int value) { stored = value; }
    public int Read() { return this.stored; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Beacon beacon = new Beacon();
        beacon.Set(61);
        Check(beacon.Read() == 61, "class-construction-and-members");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
