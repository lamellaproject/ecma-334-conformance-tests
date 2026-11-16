/*
Rules: E12-8-16-3-initializable-members; E12-8-16-3-brace-form; E12-8-16-3-trailing-comma-form; E12-8-16-3-member-list-form; E12-8-16-3-member-form; E12-8-16-3-identifier-target-form; E12-8-16-3-expression-value-form; E12-8-16-3-expression-assignment; E12-8-16-2-constructor-before-initializer
Authority: ECMA-334 7th ed 12.8.16.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Field = Read(18, "F")
Into: Field = Read(28, "F")
*/
using System;
class Packet
{
    public int Field, Stored;
    public Packet() { Program.trace += "C"; }
    public int Property { set { Program.trace += "S"; Stored = value; } }
}
class Program
{
    public static string trace = "";
    static int checks, failures;
    static int Read(int value, string label) { trace += label; return value; }
    static void Check(bool condition, string label)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + label); }
    }
    static int Main()
    {
        Packet packet = new Packet { Field = Read(18, "F"), Property = Read(32, "P"), };
        Check(trace == "CFPS", "constructor-before-written-initializer-order");
        Check(packet.Field == 18, "field-assignment-value");
        Check(packet.Stored == 32, "property-setter-value");
        Packet empty = new Packet { };
        Check(empty.Field == 0 && trace == "CFPSC", "empty-object-initializer");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
