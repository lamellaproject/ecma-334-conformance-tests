/*
Rules: P10-record-struct-matching; P10-record-struct-equatable
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 3
Mutate: public override string ToString() { return "custom:" + name; }
Into: public override string ToString() { return "fallback:" + name; }
*/
using System;
readonly record struct Ticket
{
    readonly string name;
    public Ticket(string name) { this.name = name; }
    public override string ToString() { return "custom:" + name; }
}
class Program
{
    static int checks, failures;
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Ticket value = new Ticket("hemlock");
        Check(value.ToString() == "custom:hemlock", "explicit-print-selected");
        Check(((object)value).ToString() == "custom:hemlock", "boxed-print-selected");
        IEquatable<Ticket> contract = value;
        Check(contract.Equals(new Ticket("hemlock")), "other-member-still-synthesized");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
