/*
Rules: P09-record-hash-fields
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 3
Mutate: record Digest(Cell First, Cell Second);
Into: record Digest(Cell First, Cell Second) { public override int GetHashCode() { return 0; } }
*/
using System;
class Cell
{
    public static int Calls;
    readonly int value;
    public Cell(int value) { this.value = value; }
    public override bool Equals(object other) { return other is Cell && value == ((Cell)other).value; }
    public override int GetHashCode() { Calls++; return value; }
}
record Digest(Cell First, Cell Second);
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
        Digest a = new Digest(new Cell(8), new Cell(31));
        Digest b = new Digest(new Cell(8), new Cell(31));
        Cell.Calls = 0;
        int first = a.GetHashCode();
        Check(Cell.Calls == 2, "each-instance-field");
        int second = b.GetHashCode();
        Check(first == second, "equal-values-same-hash");
        Check(Cell.Calls == 4, "second-record-fields");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
