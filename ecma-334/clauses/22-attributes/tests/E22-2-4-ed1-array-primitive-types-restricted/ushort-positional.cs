/*
Rules: E22-2-4-ed1-array-primitive-types-restricted
Authority: ECMA-334 1st ed 24.1.3
Version: ISO-1
Expected: reject
Version-Witness: E22-2-4-ed1-array-primitive-types-restricted/ushort-positional-positive.cs.part
Mutate: using LaneItem = System.UInt16;
Into: using LaneItem = System.Int32;
*/
using LaneItem = System.UInt16;

// ECMA-334 1st ed 24.1.3, p. 311 (PDF p. 325), line 13. Refuse use of one-dimensional
// arrays of sbyte, ushort, uint, or ulong as positional or named attribute parameter
// types.

public class BundleAttribute : System.Attribute
{
    public BundleAttribute(LaneItem[] items) { }
}

[Bundle(new LaneItem[] { })]
class ArrayMarked { }

class ArrayEntry
{
    public static int Main() { return 0; }
}
