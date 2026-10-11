/*
Rules: E15-7-1-property-accessor-actions; E15-7-1-property-accessor-read-write-statements; E15-7-1-grammar-property-declaration-form-1; E15-7-1-grammar-property-body-form-1; E15-7-1-property-characteristic; E15-7-1-nonref-property-value-type; E15-7-1-nonref-property-readable-writable; E15-7-1-property-name; E15-7-1-property-statement-body-accessors
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: stored = value + 6;
Into: stored = value;
*/
using System;
class Meter
{
    int stored;
    public string Trace = "";
    public int Reading
    {
        get { Trace += "r"; return stored - 2; }
        set { Trace += "w"; stored = value + 6; }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Meter meter = new Meter();
        meter.Reading = 11;
        Check(meter.Trace == "w", "write-action");
        int read = meter.Reading;
        Check(read == 15, "read-computed-value");
        Check(meter.Trace == "wr", "read-action");
        meter.Reading = meter.Reading + 1;
        Check(meter.Trace == "wrrw" && meter.Reading == 20, "read-then-write");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
