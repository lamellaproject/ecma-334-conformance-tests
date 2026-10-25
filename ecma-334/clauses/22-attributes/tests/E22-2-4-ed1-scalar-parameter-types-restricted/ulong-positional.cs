/*
Rules: E22-2-4-ed1-scalar-parameter-types-restricted
Authority: ECMA-334 1st ed 24.1.3
Version: ISO-1
Expected: reject
Version-Witness: tests/E22-2-4-ed1-scalar-parameter-types-restricted/ulong-positional.witness.cs.part
Mutate: ulong amount
Into: int amount
*/
// ECMA-334 1st ed 24.1.3, p. 311 (PDF p. 325), lines 6-8. Refuse use of sbyte, ushort,
// uint, or ulong as a scalar positional or named attribute parameter type.

public class GrainAttribute : System.Attribute
{
    public GrainAttribute(ulong amount) { }
}

[Grain(19)]
class MarkedEntity { }

class ScalarEntry
{
    public static int Main() { return 0; }
}
