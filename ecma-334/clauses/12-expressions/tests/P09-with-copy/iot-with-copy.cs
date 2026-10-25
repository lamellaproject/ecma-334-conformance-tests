/*
Rules: P09-with-copy; P09-record-copy-fields; P09-record-copy-no-initializers
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 8
Mutate: Packet changed = original with { Tag = 9 };
Into: Packet changed = original with { Tag = 8 };
*/
using System;
class Cell { public int Value; }
record Packet
{
    public static int Starts;
    public int Stamp = ++Starts;
    public int Number;
    public Cell Shared;
    public int Tag { get; init; }
}
class Program
{
    static int checks, failures;
    static void Check(bool value, string name) { checks++; if (!value) { failures++; Console.WriteLine("FAIL " + name); } }
    static int Main()
    {
        Packet original = new Packet { Number = 6, Shared = new Cell { Value = 4 }, Tag = 2 };
        Packet changed = original with { Tag = 9 };
        Packet unchanged = original with { };
        Check(!ReferenceEquals(original, changed), "modified-copy-distinct");
        Check(changed.Tag == 9 && original.Tag == 2, "change-only-copy");
        Check(changed.Number == 6 && changed.Stamp == original.Stamp, "declared-fields-copied");
        Check(ReferenceEquals(changed.Shared, original.Shared), "reference-field-shallow-copy");
        Check(Packet.Starts == 1, "initializers-not-repeated");
        Check(!ReferenceEquals(original, unchanged), "empty-copy-distinct");
        Check(unchanged.Tag == 2 && unchanged.Number == 6, "empty-copy-state");
        changed.Shared.Value = 7;
        Check(original.Shared.Value == 7, "shared-object-retained");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
