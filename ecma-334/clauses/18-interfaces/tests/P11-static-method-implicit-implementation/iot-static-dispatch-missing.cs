/*
Rules: P11-static-method-implicit-implementation; E18-1-contract
Authority: csc 5.11.0-1.26425.128 (C# 11.0)
Version: 11.0
Expected: reject
Mutate: struct Parcel : IDecoder { }
Into: struct Parcel : IDecoder { public static int Decode(int value) { return value + 13; } }
Csc: CS0535
*/
// Proposal L10/L119: the implementing type must satisfy the abstract slot.
interface IDecoder { static abstract int Decode(int value); }
struct Parcel : IDecoder { }
class Program { static void Main() { } }
