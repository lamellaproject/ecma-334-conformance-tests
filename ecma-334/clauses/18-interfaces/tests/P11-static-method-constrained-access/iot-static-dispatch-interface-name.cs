/*
Rules: P11-static-method-constrained-access
Authority: csc 5.11.0-1.26425.128 (C# 11.0)
Version: 11.0
Expected: reject
Mutate: return IDecoder.Decode(value);
Into: return T.Decode(value);
Csc: CS8926
*/
// Proposal L175: static abstract access is through the constrained type parameter.
interface IDecoder { static abstract int Decode(int value); }
struct Parcel : IDecoder { public static int Decode(int value) { return value + 13; } }
class Program
{
    static int Decode<T>(int value) where T : IDecoder { return IDecoder.Decode(value); }
    static void Main() { Decode<Parcel>(8); }
}
