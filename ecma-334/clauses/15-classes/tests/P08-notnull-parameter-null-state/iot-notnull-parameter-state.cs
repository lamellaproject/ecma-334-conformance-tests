/*
Rules: P08-notnull-parameter-null-state
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 2
Diagnostic: none
Mutate: static int Hash<T>(T value) where T : notnull
Into: static int Hash<T>(T value)
*/
#nullable enable
using System;
class Marker
{
    public override int GetHashCode() { return 31; }
}
class Program
{
    static int checks, failures;
    static int Hash<T>(T value) where T : notnull
    {
        return value.GetHashCode();
    }
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Check(Hash(new Marker()) == 31, "notnull-reference-parameter-state");
        Check(Hash(23) == 23, "notnull-value-parameter-state");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
