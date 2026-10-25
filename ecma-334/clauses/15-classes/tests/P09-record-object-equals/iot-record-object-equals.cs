/*
Rules: P09-record-object-equals
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 4
Mutate: record Match
Into: class Match
*/
using System;
record Match
{
    readonly int key;
    public Match(int key) { this.key = key; }
    public virtual bool Equals(Match other) { return !object.ReferenceEquals(other, null) && key == other.key; }
    public override int GetHashCode() { return key; }
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
        object a = new Match(14);
        Check(a.Equals(new Match(14)), "object-override");
        Check(!a.Equals(new Match(15)), "unequal-state");
        Check(!a.Equals("14"), "wrong-type");
        Check(!a.Equals(null), "null-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
