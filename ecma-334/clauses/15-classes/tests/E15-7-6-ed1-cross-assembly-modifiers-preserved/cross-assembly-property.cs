/*
Rules: E15-7-6-ed1-cross-assembly-modifiers-preserved
Authority: ECMA-334 1st ed 17.6.3
Version: ISO-1
Expected: run
Stdout: OK 0
Diagnostic: none
Fixture: {"libraries":[{"name":"Base","units":[{"source":"tests/E15-7-6-ed1-cross-assembly-modifiers-preserved/base.cs.part"}]}],"program":{"references":[{"library":"Base"}]}}
Version-Witness: tests/E15-7-6-ed1-cross-assembly-modifiers-preserved/same-assembly-witness.cs.part
Mutate: protected internal override int Signal { get { return 17; } }
Into: public override int Signal { get { return 17; } }
*/
// Old 17.6.3, p. 248 (PDF p. 262), lines 23-24 requires matching declared accessibility.
// Later 15.7.6 adds a different-assembly protected exception.
// Declaration permission only: OK 0 has no runtime cases.
// csc rejects the old-valid original; no conforming-original sensitivity is claimed.
class Branch : RemoteRoot
{
    protected internal override int Signal { get { return 17; } }
}
class Entry
{
    public static int Main()
    {
        System.Console.WriteLine("OK 0");
        return 0;
    }
}
