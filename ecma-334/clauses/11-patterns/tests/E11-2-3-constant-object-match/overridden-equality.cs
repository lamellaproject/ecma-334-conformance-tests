/*
Rules: E11-2-3-constant-object-match; E11-2-3-constant-convert-other
Authority: ECMA-334 7th ed 11.2.3
Version: 7.3
Expected: run
Stdout: OK 2
Version-Witness: version-witnesses/overridden-equality-82c8b4e361.cs.part
Mutate: input is 29
Into: input is EqualTo value
*/
using System;
class EqualTo
{
    public static int calls;
    public override bool Equals(object other) { calls++; return other is int && (int)other == 29; }
    public override int GetHashCode() { return 29; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object input = new EqualTo();
        bool matched = input is 29;
        Check(matched, "object-equals-match");
        Check(EqualTo.calls == 1, "object-equals-invoked");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
