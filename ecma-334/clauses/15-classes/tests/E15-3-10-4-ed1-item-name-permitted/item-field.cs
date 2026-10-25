/*
Rules: E15-3-10-4-ed1-item-name-permitted
Authority: ECMA-334 1st ed 17.2.7.3
Version: ISO-1
Expected: run
Stdout: OK 2
Version-Witness: tests/E15-3-10-4-ed1-item-name-permitted/item-field-repair.cs.part
Mutate: public new int Item
Into: public int Member
*/
using System;

// ECMA-334 1st ed 17.2.7.3, p. 221 (PDF p. 235), lines 29-32. Permit an otherwise valid
// member named Item in a class declaring an indexer; the indexer reservation is limited to
// its accessor method signatures.

class ParcelBase
{
    public int Item = -17;
}

class Parcel : ParcelBase
{
    public new int Item = 13;

    public int this[int position]
    {
        get { return position * 6 - 1; }
    }
}

class TestMain
{
    private static int checks;
    private static int failures;

    private static void Check(bool condition, string name)
    {
        checks++;
        if (!condition)
        {
            failures++;
            Console.WriteLine("FAIL " + name);
        }
    }

    public static int Main()
    {
        Parcel value = new Parcel();
        Check(value[7] == 41, "indexer");
        Check(value.Item == 13, "named-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
