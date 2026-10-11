/*
Rules: E12-8-22-this-target-form; E12-8-22-entity-form
Authority: ECMA-334 7th ed 12.8.22
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: nameof(this.Number)
Into: nameof(this.Other)
*/
using System;
class Receiver
{
    public int Number, Other;
    public string ReadName() { return nameof(this.Number); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Receiver().ReadName() == "Number", "this-starts-named-entity");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
