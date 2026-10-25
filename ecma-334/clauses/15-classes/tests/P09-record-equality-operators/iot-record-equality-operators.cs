/*
Rules: P09-record-equality-operators
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 7
Mutate: record Parity
Into: class Parity
*/
using System;
record Parity
{
    public static int Calls;
    readonly int number;
    public Parity(int number) { this.number = number; }
    public virtual bool Equals(Parity other)
    {
        Calls++;
        return !object.ReferenceEquals(other, null) && (number & 1) == (other.number & 1);
    }
    public override int GetHashCode() { return number & 1; }
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
        Parity a = new Parity(3), b = new Parity(9), c = new Parity(4), nil = null;
        Parity.Calls = 0;
        Check(a == b, "typed-equals-dispatch");
        Check(Parity.Calls == 1, "one-equals-call");
        Check(!(a != b) && a != c, "inequality-complement");
        Check(nil == (Parity)null && !(nil != (Parity)null), "two-nulls");
        Check(nil != a && !(nil == a), "left-null");
        Check(a != nil && !(a == nil), "right-null");
        Parity alias = a;
        Check(a == alias, "identity-shortcut");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
