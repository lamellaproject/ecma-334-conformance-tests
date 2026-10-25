/*
Rules: P10-record-struct-equatable; P09-record-equality-operators; P09-record-object-equals; P10-record-struct-matching
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 8
Mutate: public bool Equals(Reading other) { return key % 10 == other.key % 10; }
Into: public bool Equals(Reading other) { return key == other.key; }
*/
using System;
readonly record struct Reading
{
    readonly int key;
    public Reading(int value) { key = value; }
    public bool Equals(Reading other) { return key % 10 == other.key % 10; }
    public override int GetHashCode() { return key % 10; }
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
        Reading a = new Reading(24), b = new Reading(54), c = new Reading(25);
        IEquatable<Reading> dispatch = a;
        Check(dispatch.Equals(b), "interface-matching-equals");
        Check(a == b, "operator-matching-equals");
        Check(!(a != b), "inequality-complement");
        Check(a != c, "unequal-values");
        Check(a.Equals((object)b), "object-same-record-type");
        Check(!a.Equals((object)24), "object-unrelated-type");
        Check(!a.Equals((object)null), "object-null");
        Check(a.GetHashCode() == b.GetHashCode(), "custom-hash-retained");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
