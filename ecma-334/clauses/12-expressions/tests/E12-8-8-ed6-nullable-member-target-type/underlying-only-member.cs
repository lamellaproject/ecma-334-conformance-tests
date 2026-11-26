/*
Rules: E12-8-8-ed6-nullable-member-target-type
Authority: ECMA-334 6th ed 11.7.7
Version: 6
Expected: reject
Version-Witness: tests/E12-8-8-ed6-nullable-member-target-type/underlying-only-member.witness.cs.part
Mutate: receiver?.Code
Into: receiver.Value.Code
*/
using System;

struct Stamp
{
    public readonly int Code;
    public Stamp(int code) { Code = code; }
}

class Program
{
    static int? Read(Stamp? receiver) { return receiver?.Code; }

    static int checks;
    static int failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Stamp? stamp = new Stamp(31);
        Check(Read(stamp) == 31, "present-code");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
