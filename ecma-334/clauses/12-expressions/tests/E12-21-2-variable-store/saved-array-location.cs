/*
Rules: E12-21-2-variable-store; E12-21-2-variable-result; E12-21-2-evaluate-left-first; E12-21-2-variable-evaluate-right; E12-21-2-variable-convert-right; E12-21-2-variable-assignment-type; E12-21-1-assignment-form; E12-21-1-simple-form; E12-21-1-simple-name; E12-21-1-value-assignment; E12-21-1-simple-target-values; E12-22-assignment-form
Authority: ECMA-334 7th ed 12.21.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Array()[Index()] = Produce()
Into: Array()[Index() + 1] = Produce()
*/
using System;
struct Input
{
    public int Number;
    public Input(int number) { Number = number; }
    public static implicit operator int(Input input) { Program.trace += "C"; return input.Number * 3; }
}
class Program
{
    public static string trace = "";
    static int[] original = new int[2], decoy = new int[] { -1, -1 }, current = original;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int[] Array() { trace += "A"; return current; }
    static int Index() { trace += "I"; return 0; }
    static Input Produce() { trace += "R"; current = decoy; return new Input(11); }
    static bool IsInt(int value) { return true; }
    static bool IsInt(Input value) { return false; }
    static void Main()
    {
        var result = (Array()[Index()] = Produce());
        Check(original[0] == 33 && original[1] == 0 && decoy[0] == -1, "saved-left-location");
        Check(IsInt(result) && result == 33, "converted-assignment-type-and-result");
        Check(trace == "AIRC", "left-right-conversion-order");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
