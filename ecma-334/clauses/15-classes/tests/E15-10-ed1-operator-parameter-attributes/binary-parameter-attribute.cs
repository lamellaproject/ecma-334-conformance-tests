/*
Rules: E15-10-ed1-operator-parameter-attributes
Authority: ECMA-334 1st ed 17.9
Version: ISO-1
Expected: reject
Version-Witness: tests/E15-10-ed1-operator-parameter-attributes/binary-parameter-attribute.witness.cs.part
Mutate: [Seal] int offset
Into: int offset
*/
// ECMA-334 1st ed 17.9, p. 258 (PDF p. 272), lines 1-11. Unary, binary and conversion
// operator parameter productions are type followed by identifier, without attributes.
using System;
class SealAttribute : Attribute { }
class Packet
{
    public int Value;
    public Packet(int value) { Value = value; }
    public static int operator +(Packet item, [Seal] int offset) { return item.Value + offset; }
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
        int result = new Packet(480) + 7;
        Check(result == 487, "attribute-free-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
