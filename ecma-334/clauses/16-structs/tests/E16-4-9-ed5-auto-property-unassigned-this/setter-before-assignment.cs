/*
Rules: E16-4-9-ed5-auto-property-unassigned-this
Authority: ECMA-334 5th ed 16.4.9
Version: 5
Expected: reject
Version-Witness: version-witnesses/E16-4-9-ed5-auto-property-unassigned-this/setter-before-assignment.cs.part
Mutate: public Gauge(int value)
Into: public Gauge(int value) : this()
*/
// ECMA-334 5th ed 16.4.9, p. 349 (PDF p. 371), and 16.4.11, p. 350 (PDF p. 372).
// A property setter cannot read the struct receiver before its definite assignment.
using System;
struct Gauge
{
    public int Score { get; set; }
    public Gauge(int value) { Score = value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        int input = 31;
        Gauge value = new Gauge(input);
        Check(value.Score == input, "initialized-auto-property");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
