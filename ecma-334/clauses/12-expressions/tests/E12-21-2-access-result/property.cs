/*
Rules: E12-21-2-access-result; E12-21-2-access-evaluate-right; E12-21-2-access-convert-right; E12-21-2-access-setter; E12-21-2-access-assignment-type
Authority: ECMA-334 7th ed 12.21.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Receiver().WriteOnly = Produce()
Into: Receiver().WriteOnly = Produce() + 1L
*/
using System;
struct Input
{
    public static implicit operator long(Input input) { Program.trace += "C"; return 27L; }
}
class Storage
{
    public long Stored;
    public long WriteOnly { set { Program.trace += "S"; Stored = value + 100L; } }
}
class Program
{
    public static string trace = "";
    static Storage target = new Storage();
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Storage Receiver() { trace += "E"; return target; }
    static Input Produce() { trace += "R"; return new Input(); }
    static bool IsLong(long value) { return true; }
    static bool IsLong(Input value) { return false; }
    static void Main()
    {
        var result = (Receiver().WriteOnly = Produce());
        Check(target.Stored == 127L, "setter-receives-converted-value");
        Check(IsLong(result) && result == 27L, "result-independent-of-setter-storage");
        Check(trace == "ERCS", "property-receiver-right-conversion-setter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
