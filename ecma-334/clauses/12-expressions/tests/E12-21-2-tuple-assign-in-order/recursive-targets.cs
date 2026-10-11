/*
Rules: E12-21-2-tuple-assign-in-order; E12-21-2-tuple-no-left-reevaluation; E12-21-2-tuple-deconstruct-right; E12-21-2-tuple-convert-result; E12-21-2-tuple-result; E12-21-2-tuple-assignment-type; E12-21-2-deconstruction-definition
Authority: ECMA-334 7th ed 12.21.2
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: (Receiver().First, Receiver()[Index()])
Into: (Receiver()[Index()], Receiver().First)
*/
using System;
struct Input
{
    public int Number;
    public string Label;
    public Input(int number, string label) { Number = number; Label = label; }
    public static implicit operator Value(Input input) { Program.trace += "C" + input.Label; return new Value(input.Number); }
}
struct Value
{
    public int Number;
    public Value(int number) { Number = number; }
}
class Packet
{
    public void Deconstruct(out Input first, out Input second)
    {
        Program.trace += "D";
        first = new Input(31, "1"); second = new Input(47, "2");
    }
}
class Storage
{
    public int Number, Key;
    public string Label;
    public Storage(string label) { Label = label; }
    public Value First { set { Program.trace += "s" + Label; Number = value.Number + 100; } }
    public Value this[int key] { set { Program.trace += "s" + Label; Number = value.Number + 100; Key = key; } }
}
class Program
{
    public static string trace = "";
    static Storage first = new Storage("1"), second = new Storage("2"), decoy = new Storage("x");
    static int receivers;
    static bool replace;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Storage Receiver() { receivers++; trace += "r" + receivers; return replace ? decoy : receivers == 1 ? first : second; }
    static int Index() { trace += "i"; return 4; }
    static Packet Right() { trace += "V"; replace = true; return new Packet(); }
    static bool CorrectType((Value, Value) value) { return true; }
    static bool CorrectType((Input, Input) value) { return false; }
    static void Main()
    {
        var result = ((Receiver().First, Receiver()[Index()]) = Right());
        Check(first.Number == 131 && second.Number == 147 && second.Key == 4, "ordered-recursive-stores");
        Check(decoy.Number == 0 && receivers == 2, "left-targets-not-reevaluated");
        Check(CorrectType(result) && result.Item1.Number == 31 && result.Item2.Number == 47, "converted-tuple-result-and-type");
        Check(trace == "r1r2iVDC1C2s1s2", "locations-deconstruct-convert-then-stores");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
