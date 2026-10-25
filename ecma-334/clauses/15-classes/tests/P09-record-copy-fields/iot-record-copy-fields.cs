/*
Rules: P09-record-copy-fields; P09-record-copy-no-initializers
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 5
Mutate: return new Parcel(this);
Into: return new Parcel();
*/
using System;
class Cell { public int Value; }
class Probe
{
    public static int Calls;
    public static int Next() { Calls++; return Calls; }
}
record Parcel
{
    public int Serial = Probe.Next();
    public Cell Payload;
    public Parcel Copy() { return new Parcel(this); }
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
        Probe.Calls = 0;
        Parcel a = new Parcel();
        a.Serial = 73;
        a.Payload = new Cell { Value = 12 };
        Parcel b = a.Copy();
        Check(!object.ReferenceEquals(a, b), "new-reference");
        Check(b.Serial == 73, "copied-value-field");
        Check(Probe.Calls == 1, "no-initializer-reexecution");
        Check(object.ReferenceEquals(a.Payload, b.Payload), "copied-reference-field");
        a.Payload.Value = 44;
        Check(b.Payload != null && b.Payload.Value == 44, "shallow-copy");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
