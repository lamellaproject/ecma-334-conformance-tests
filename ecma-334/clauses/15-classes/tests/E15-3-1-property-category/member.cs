/*
Rules: E15-3-1-property-category; E15-3-1-grammar-class-member-declaration-form-4
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: set { number = value + 2; Writes++; }
Into: set { number = value; }
*/
using System;
class Gauge
{
    int number;
    public int Reads, Writes;
    public int Level
    {
        get { Reads++; return number; }
        set { number = value + 2; Writes++; }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge value = new Gauge();
        value.Level = 107;
        Check(value.Level == 109, "named-property-reading-and-writing");
        Check(value.Reads == 1 && value.Writes == 1, "property-actions-executed");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
