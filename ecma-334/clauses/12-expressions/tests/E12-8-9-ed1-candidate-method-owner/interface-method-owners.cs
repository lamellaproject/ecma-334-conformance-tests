/*
Rules: E12-8-9-ed1-candidate-method-owner
Authority: ECMA-334 1st ed 14.5.5.1
Version: ISO-1
Expected: reject
Version-Witness: tests/E12-8-9-ed1-candidate-method-owner/interface-method-owners.witness.cs.part
Mutate: reader.Read("tile")
Into: ((INarrow)reader).Read("tile")
*/
// ECMA-334 1st ed 14.5.5.1, p. 143 (PDF p. 157), lines 6-12. After applicability and
// hiding reduction, candidate methods for an invocation must all be declared in one type.
using System;
interface IWide { int Read(object key); }
interface INarrow { int Read(string key); }
interface ICombined : IWide, INarrow { }
class Reader : ICombined
{
    public int Read(object key) { return 9; }
    public int Read(string key) { return 41; }
}
class Entry
{
    static int checks;
    static int failures;
    static void Check(bool result, string label)
    {
        checks++;
        if (!result)
        {
            failures++;
            Console.WriteLine("FAIL " + label);
        }
    }
    static int Main()
    {
        ICombined reader = new Reader();
        Check(reader.Read("tile") == 41, "single-owner-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
