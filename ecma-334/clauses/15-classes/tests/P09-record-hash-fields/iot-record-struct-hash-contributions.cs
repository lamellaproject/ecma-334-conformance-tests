/*
Rules: P09-record-hash-fields
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 3
Mutate: readonly record struct Basket {
Into: readonly record struct Basket { public override int GetHashCode() { return left.GetHashCode(); }
*/
using System;
struct Part : IEquatable<Part>
{
    public static int Calls, Seen;
    readonly int code;
    public Part(int code) { this.code = code; }
    public bool Equals(Part other) { return code == other.code; }
    public override bool Equals(object value) { return value is Part && Equals((Part)value); }
    public override int GetHashCode() { Calls++; Seen |= 1 << code; return code * 19; }
}
readonly record struct Basket {
    readonly Part left, right;
    public Basket(Part left, Part right) { this.left = left; this.right = right; }
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
        Basket a = new Basket(new Part(1), new Part(3));
        int hash = a.GetHashCode();
        Check(Part.Calls == 2, "each-field-hashed-once");
        Check(Part.Seen == 10, "both-default-comparer-contributions");
        Check(new Basket(new Part(1), new Part(3)).GetHashCode() == hash, "equal-hash-consistency");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
