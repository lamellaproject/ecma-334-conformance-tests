/*
Rules: E12-21-4-ed1-shift-rhs-implicit-conversion
Authority: ECMA-334 1st ed 14.13.2
Version: ISO-1
Expected: reject
Version-Witness: tests/E12-21-4-ed1-shift-rhs-implicit-conversion/byte-compound-int-shift.witness.cs.part
Mutate: bits <<= amount;
Into: bits <<= (byte)amount;
*/
// ECMA-334 1st ed 14.13.2, p. 175 (PDF p. 189), lines 42-45 has no shift exception for the
// right operand.
class Entry
{
    public static int Main()
    {
        byte bits = 21;
        int amount = 1;
        bits <<= amount;
        return bits == 42 ? 0 : 1;
    }
}
