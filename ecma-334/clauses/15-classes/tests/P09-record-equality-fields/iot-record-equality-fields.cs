/*
Rules: P09-record-equality-fields
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 5
Mutate: record Meter(int Level, Cell Tag);
Into: record Meter(int Level, Cell Tag) { public virtual bool Equals(Meter other) { return !object.ReferenceEquals(other, null); } public override int GetHashCode() { return 0; } }
*/
using System;
class Cell : IEquatable<Cell>
{
    readonly int code;
    public Cell(int code) { this.code = code; }
    public bool Equals(Cell other) { return !object.ReferenceEquals(other, null) && code == other.code; }
    public override bool Equals(object other) { return Equals(other as Cell); }
    public override int GetHashCode() { return code; }
}
record Meter(int Level, Cell Tag);
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
        Meter a = new Meter(6, new Cell(29));
        Meter b = new Meter(6, new Cell(29));
        Check(!object.ReferenceEquals(a, b) && !object.ReferenceEquals(a.Tag, b.Tag), "fresh-references");
        Check(a.Equals(b), "field-value-equality");
        Check(!a.Equals(new Meter(7, new Cell(29))), "numeric-field-difference");
        Check(!a.Equals(new Meter(6, new Cell(30))), "reference-field-comparer");
        Check(!a.Equals((Meter)null), "null-is-unequal");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
