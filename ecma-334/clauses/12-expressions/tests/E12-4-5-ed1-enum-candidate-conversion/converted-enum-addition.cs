/*
Rules: E12-4-5-ed1-enum-candidate-conversion
Authority: ECMA-334 1st ed 14.2.4
Version: ISO-1
Expected: run
Stdout: OK 2
Version-Witness: tests/E12-4-5-ed1-enum-candidate-conversion/converted-enum-addition.witness.cs.part
Mutate: Bits result = item + amount;
Into: Bits result = (Bits)(17 - amount);
*/
// ECMA-334 1st ed 14.2.4, p. 127 (PDF p. 141), lines 18-24. When no user-defined binary
// operator is applicable, enum predefined operators participate through implicit operand
// conversions even when neither operand initially has that enum type.
using System;
enum Bits { Seed = 17 }
class Parcel
{
    public static int conversions;
    public static implicit operator Bits(Parcel item)
    {
        conversions++;
        return Bits.Seed;
    }
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
        Parcel item = new Parcel();
        int amount = 5;
        Bits result = item + amount;
        Check(result == (Bits)22, "addition");
        Check(Parcel.conversions == 1, "operand-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
