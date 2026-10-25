/*
Rules: E15-6-5-ed1-cross-assembly-declared-access-preserved
Authority: ECMA-334 1st ed 17.5.4
Version: ISO-1
Expected: run
Stdout: OK 0
Diagnostic: none
Fixture: {"libraries":[{"name":"Base","units":[{"source":"tests/E15-6-5-ed1-cross-assembly-declared-access-preserved/base.cs.part"}]}],"program":{"references":[{"library":"Base"}]}}
Version-Witness: tests/E15-6-5-ed1-cross-assembly-declared-access-preserved/same-assembly-witness.cs.part
Mutate: protected internal override int Signal() { return 17; }
Into: public override int Signal() { return 17; }
*/
// Old 17.5.4, p. 238 (PDF p. 252), lines 23-24 requires matching declared accessibility.
// Later 15.6.5 adds a different-assembly protected exception.
// Declaration permission only: OK 0 has no runtime cases.
// csc rejects the old-valid original; no conforming-original sensitivity is claimed.
class Branch : RemoteRoot
{
    protected internal override int Signal() { return 17; }
}
class Entry
{
    public static int Main()
    {
        System.Console.WriteLine("OK 0");
        return 0;
    }
}
