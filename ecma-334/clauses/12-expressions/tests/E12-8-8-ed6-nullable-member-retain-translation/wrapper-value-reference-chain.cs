/*
Rules: E12-8-8-ed6-nullable-member-retain-translation
Authority: ECMA-334 6th ed 11.7.7
Version: 6
Expected: run
Stdout: OK 4
Version-Witness: tests/E12-8-8-ed6-nullable-member-retain-translation/wrapper-value-reference-chain.witness.cs.part
Mutate: return "outer";
Into: return "other";
*/
using System;

class Tag
{
    public string Label { get { return "inner"; } }
}
struct Sample
{
    public static int ValueCalls;
    public string Label { get { return "outer"; } }
    public Tag Value { get { ValueCalls++; return new Tag(); } }
}

class Program
{
    static int reads;
    static Sample? Read(bool present)
    {
        reads++;
        if (present) return new Sample();
        return null;
    }

    static int checks;
    static int failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        string present = Read(true)?.Value.Label;
        string absent = Read(false)?.Value.Label;
        Check(present == "outer", "wrapper-value-label");
        Check(absent == null, "absent-reference-result");
        Check(reads == 2, "receiver-evaluated-once-per-access");
        Check(Sample.ValueCalls == 0, "underlying-value-unused");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
