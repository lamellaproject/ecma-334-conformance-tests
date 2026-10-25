/*
Rules: P11-static-method-constrained-access
Authority: csc 5.11.0-1.26425.128 (C# 11.0)
Version: 11.0
Expected: reject
Mutate: static int Decode<T>(int value)
Into: static int Decode<T>(int value) where T : IDecoder
Csc: CS0704
*/
// Proposal L175: a type-parameter call needs the interface constraint.
interface IDecoder { static abstract int Decode(int value); }
struct Parcel : IDecoder { public static int Decode(int value) { return value + 13; } }
class Program
{
    static int Decode<T>(int value) { return T.Decode(value); }
    static void Main() { Decode<Parcel>(8); }
}
