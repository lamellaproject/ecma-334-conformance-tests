/*
Rules: P09-record-equality-fields; P10-record-struct-equatable
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 5
Mutate: readonly record struct Badge {
Into: readonly record struct Badge { public bool Equals(Badge other) { return code == other.code; }
*/
using System;
readonly record struct Badge {
    readonly int code;
    readonly float score;
    readonly string tag;
    public Badge(int code, float score, string tag) { this.code = code; this.score = score; this.tag = tag; }
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
        Badge a = new Badge(3, float.NaN, "reed");
        Check(a.Equals(new Badge(3, float.NaN, new string(new char[] { 'r', 'e', 'e', 'd' }))), "default-comparer-nan-and-string");
        Check(!a.Equals(new Badge(4, float.NaN, "reed")), "private-first-field");
        Check(!a.Equals(new Badge(3, 0.0f, "reed")), "private-second-field");
        Check(!a.Equals(new Badge(3, float.NaN, "fern")), "private-third-field");
        IEquatable<Badge> contract = a;
        Check(contract.Equals(a), "synthesized-interface-equality");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
